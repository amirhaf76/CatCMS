using CMSApi.Controllers;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CMSApi
{

    public class JsonPatchInputFormatter : TextInputFormatter
    {
        public JsonPatchInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/json-patch"));

            SupportedEncodings.Add(Encoding.UTF8);
        }

        protected override bool CanReadType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(JsonPatchRequest<>);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
        InputFormatterContext context, Encoding effectiveEncoding)
        {
            var httpContext = context.HttpContext;
            var serviceProvider = httpContext.RequestServices;

            var logger = serviceProvider.GetRequiredService<ILogger<JsonPatchInputFormatter>>();

            using var reader = new StreamReader(httpContext.Request.Body, effectiveEncoding);
            string? nameLine = null;


            var doc = await JsonDocument.ParseAsync(httpContext.Request.Body, new JsonDocumentOptions
            {
                AllowTrailingCommas = true,
                
            });

            try
            {
                var obj = Activator.CreateInstance(context.ModelType);

                var result = GetPropertyFromObj(obj, context.ModelType, doc.RootElement);
                logger.LogInformation("nameLine = {nameLine}", nameLine);

                return await InputFormatterResult.SuccessAsync(result);
            }
            catch
            {
                logger.LogError("Read failed: nameLine = {nameLine}", nameLine);
                return await InputFormatterResult.FailureAsync();
            }
        }


        private object GetPropertyFromObj(object? obj, Type type, JsonElement jsonElement)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            var theProperties = type.GetProperties();

            foreach (var theProperty in theProperties)
            {
                var propertyType = theProperty.PropertyType;

                if (propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = propertyType.GetGenericArguments()[0];
                }
                
                if (jsonElement.TryGetProperty(theProperty.Name, out JsonElement jsonPropertyValue))
                {

                    if (propertyType == typeof(string))
                    {
                        theProperty.SetValue(obj, jsonPropertyValue.GetString());
                    }
                    else if (propertyType == typeof(int))
                    {
                        theProperty.SetValue(obj, jsonPropertyValue.GetInt32());
                    }
                    else if (propertyType == typeof(double))
                    {
                        theProperty.SetValue(obj, jsonPropertyValue.GetDouble());
                    }
                    else if (propertyType == typeof(decimal))
                    {
                        theProperty.SetValue(obj, jsonPropertyValue.GetDecimal());
                    }
                    else if (propertyType == typeof(long))
                    {
                        theProperty.SetValue(obj, jsonPropertyValue.GetInt64());
                    }
                    else if (propertyType == typeof(short))
                    {
                        theProperty.SetValue(obj, jsonPropertyValue.GetInt16());
                    }
                    else
                    {
                        throw new InvalidOperationException($"This type of generic type is not supported.{theProperty.Name}");
                    }
                }
            }

            return obj;
        }


        private void GetPropertyFromObj(object? obj, Type type, JsonElement jsonElement, int maxDepth = 10)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }

            var theProperties = type.GetProperties();

            foreach (var theProperty in theProperties)
            {
                var propertyType = theProperty.PropertyType;

                if (propertyType.IsPrimitive)
                {
                    var jsonPropertyValue = jsonElement.GetProperty(propertyType.Name);

                    switch (jsonPropertyValue.ValueKind)
                    {
                        case JsonValueKind.Object:
                            throw new InvalidOperationException($"Object json can not be assigned to a primitive type: {propertyType} '{theProperty.Name}'");
                        case JsonValueKind.Undefined:
                            throw new InvalidOperationException($"Undefined json value is not supported.");
                        case JsonValueKind.Array:
                            throw new InvalidOperationException($"Array json can not be assigned to a primitive type: {propertyType} '{theProperty.Name}'");
                        case JsonValueKind.String:
                            theProperty.SetValue(obj, jsonPropertyValue.GetString());
                            break;
                        case JsonValueKind.Number:
                            if (propertyType == typeof(decimal))
                            {
                                theProperty.SetValue(obj, jsonPropertyValue.GetDecimal());
                            }
                            else if (propertyType == typeof(double))
                            {
                                theProperty.SetValue(obj, jsonPropertyValue.GetDouble());
                            }
                            else if (propertyType == typeof(int))
                            {
                                theProperty.SetValue(obj, jsonPropertyValue.GetInt32());
                            }
                            else if (propertyType == typeof(long))
                            {
                                theProperty.SetValue(obj, jsonPropertyValue.GetInt64());
                            }
                            else if (propertyType == typeof(short))
                            {
                                theProperty.SetValue(obj, jsonPropertyValue.GetInt16());
                            }
                            else
                            {
                                throw new InvalidOperationException($"This type of generic type is not supported.{theProperty.Name}");
                            }
                            break;
                        case JsonValueKind.True:
                        case JsonValueKind.False:
                            theProperty.SetValue(obj, jsonPropertyValue.GetBoolean());
                            break;
                        case JsonValueKind.Null:
                            if (propertyType != typeof(Nullable<>))
                            {
                                throw new InvalidOperationException($"'{propertyType.Name}' is not nullable.");
                            }
                            theProperty.SetValue(obj, null);
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    var jsonPropertyValue = jsonElement.GetProperty(propertyType.Name);

                    switch (jsonPropertyValue.ValueKind)
                    {
                        case JsonValueKind.Object:
                            var thePropertyValue = theProperty.GetValue(obj);
                            if (thePropertyValue == null)
                            {
                                try
                                {
                                    thePropertyValue = Activator.CreateInstance(propertyType);
                                }
                                catch (Exception e)
                                {
                                    throw new InvalidOperationException($"There was a problem while creating instance for null property: {theProperty.Name}", e);
                                }
                            }
                            GetPropertyFromObj(thePropertyValue, propertyType, jsonPropertyValue);
                            break;
                        case JsonValueKind.Array:
                            if (propertyType.IsAssignableFrom(typeof(List<>)))
                            {
                                var values = new List<object>();
                                var genericType = propertyType.GetGenericArguments()[0];
                                foreach (var item in jsonPropertyValue.EnumerateArray())
                                {
                                    try
                                    {
                                        var value = Activator.CreateInstance(genericType);
                                        GetPropertyFromObj(value, genericType, item);
                                    }
                                    catch (Exception e)
                                    {
                                        throw new InvalidOperationException($"There was a problem while creating instance for null property: {theProperty.Name}", e);
                                    }
                                }
                            }
                            else
                            {
                                throw new InvalidOperationException($"'{theProperty.Name}' is not assignable from list.");
                            }
                            break;
                        case JsonValueKind.Null:
                            theProperty.SetValue(obj, null);
                            break;
                        case JsonValueKind.Undefined:
                            throw new InvalidOperationException($"Undefined json value is not supported.");
                        case JsonValueKind.String:
                        case JsonValueKind.Number:
                        case JsonValueKind.True:
                        case JsonValueKind.False:
                        default:
                            throw new InvalidOperationException("it's not possible assign a primitive type to object or array ");

                    }



                }
            }
        }
    }
}
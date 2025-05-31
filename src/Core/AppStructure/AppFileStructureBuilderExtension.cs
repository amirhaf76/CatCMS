using System.Text.Json;
using System.Text.Json.Serialization;

namespace CMSCore
{
	public static class AppFileStructureBuilderExtension
    {
        public static string GetStructureView(this AppFileStructureBuilder builder) 
        {
			var options = new JsonSerializerOptions
			{
				WriteIndented = true,

			};
			options.Converters.Add(new JsonStringEnumConverter());

			return JsonSerializer.Serialize(builder.GetStructuresDto(), options);
		}
    }
}
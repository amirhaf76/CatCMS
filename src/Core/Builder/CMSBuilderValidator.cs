namespace CMSCore.Builder
{
    public class CMSBuilderValidator : ICMSBuilderValidator
    {

        public void Validate(CatCMSBuilderConfiguration config)
        {
            if (config == null) throw new ValidationOfNullException();

            CheckNullProperties(config);
        }

        private static void CheckNullProperties<T>(T obj)
        {
            var properties = typeof(T).GetProperties();

            foreach(var property in properties)
            {
                if (property.GetValue(obj) == null)  throw new DTONullPropertyException($"Value of \"{property.Name}\" Property is null!");
            }
        }
    }
}
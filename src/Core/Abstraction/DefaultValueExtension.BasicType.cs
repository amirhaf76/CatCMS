namespace CMSCore.Abstraction
{
    public static partial class DefaultValueExtension
    {
        public static bool IsDefault(this string str)
        {
            return str == string.Empty;
        }

        public static bool IsDefault(this Guid guid)
        {
            return guid == Guid.Empty;
        }

        public static bool IsDefault<T>(this IEnumerable<T> objs)
        {
            return !objs.Any();
        }
    }


    
}
namespace CMSCore.Abstraction
{
    public static class ICMSBuilderExtension
    {
        public static ICMSBuilder Config<T>(this ICMSBuilder cmsBuilder) where T : ICMSDirector
        {
            var director = Activator.CreateInstance(typeof(T), cmsBuilder);

            if (director is not null)
            {
                ((T)director).PrepareItAsDefault();
            }

            return cmsBuilder;
        }

        public static ICMSBuilder DefaultConfig(this ICMSBuilder cmsBuilder)
        {
            return cmsBuilder.Config<CMSDirector>();
        }
    }
}
namespace CMSCore.Abstraction
{
    public static partial class DefaultValueExtension
    {
        public static bool IsDefault(this Host host)
        {
            return host != null
                   && host.Id.IsDefault()
                   && host.Title.IsDefault()
                   && host.Pages != null
                   && host.Pages.IsDefault()
                   && host.Configuration != null
                   && host.Configuration.IsDefault();
        }

        public static bool IsDefault(this Page page)
        {
            return page != null
                   && page.Title.IsDefault()
                   && page.Id.IsDefault()
                   && page.Layout != null
                   && page.Components != null
                   && page.Components.IsDefault();
        }

        public static bool IsDefault(this HostConfiguration config)
        {
            return config != null
                   && config.DomainAddress == string.Empty
                   && config.GeneratedCodesDirectory == string.Empty;
        }

    }
}

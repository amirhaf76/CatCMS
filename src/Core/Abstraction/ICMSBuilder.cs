namespace CMSCore.Abstraction
{
    public interface ICMSBuilder
    {
        void SetHostFactory(IHostFactory factory);
        void SetHostRepository(IHostStorage repository);
        void SetHostGenerator(IHostGenerator generator);
        void SetPageFactory(IPageFactory factory);

        public ICMS Build();
    }
}
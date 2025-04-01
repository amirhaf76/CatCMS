using CMSCore.Abstraction;
using System.Linq.Expressions;

namespace CMSCore.Builder
{
    public class CatCMSBuilder : ICMSBuilder
    {
        private readonly ICMSBuilderValidator _validator;
        
        public CatCMSBuilderConfiguration Config { get; private set; }

        public static CatCMSBuilderConfiguration DefaultConfig
        {
            get
            {
                return new CatCMSBuilderConfiguration()
                {
                    IP = " 127.0.0.1",
                    Path = Directory.GetCurrentDirectory()
                };
            }
        }


        public CatCMSBuilder() : this(DefaultConfig)
        {
        }

        public CatCMSBuilder(CatCMSBuilderConfiguration config)
        {
            _validator = new CMSBuilderValidator();

            _validator.Validate(config);

            Config = config;
        }


        public ICMS Build()
        {
            return new CatCMS(Config.Generator, Config.Validator);
        }


        public void SetConfig(CatCMSBuilderConfiguration config)
        {
            _validator.Validate(config);

            Config = config;
        }
    }
}
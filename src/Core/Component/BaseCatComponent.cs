using CMSCore.Abstraction;
using System.Text.Json;

namespace CMSCore.Component
{
    public abstract class BaseCatComponent : ICatCMSComponent
    {

        public Guid Id { get; set; }



        public abstract string GenerateCode();

        public JsonElement Store()
        {
            throw new NotImplementedException();
        }
    }
}
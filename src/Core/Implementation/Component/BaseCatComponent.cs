using System.Reflection.Metadata;
using System.Text.Json;
using Core.Abstraction;
using Core.Enums;

namespace Core.Implementation.Component
{
    public abstract class BaseCatComponent : ICatCMSComponent
    {

        public Guid Id { get; set; }

        public abstract CatCMSComponentType Type { get; }

        public abstract string GenerateCode();

        public JsonElement Store()
        {
            throw new NotImplementedException();
        }
    }
}
using System.Text.Json;
using Core.Abstraction;
using Core.Enums;

namespace Core
{
    public abstract class BaseCatComponent : ICatCMSComponent
    {

        public Guid Id { get; set; }

        public abstract CatCMSComponentType Type { get; }

        public abstract string Generate();

        public JsonElement Store()
        {
            throw new NotImplementedException();
        }
    }
}
using CMSCore.Abstraction;
using System.Text.Json;

namespace CMSCore.Component
{
    public abstract class BaseCatComponent : ICMSComponent
    {
        // Todo: fixing hybrid structure.
        public Guid Id { get; set; } = Guid.NewGuid();

        public abstract string GenerateCode();

        public virtual JsonElement Store()
        {
            throw new NotImplementedException();
        }
    }
}
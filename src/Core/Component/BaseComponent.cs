
namespace CMSCore.Component
{
    public abstract class BaseComponent : ICMSComponent
    {
        public Guid Id { get; set; }

        // public abstract string GenerateCode();
        public string GenerateCode()
        {
            throw new NotImplementedException();
        }
    }
}
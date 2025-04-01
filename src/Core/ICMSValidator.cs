using CMSCore.Abstraction;

namespace CMSCore
{
    public interface ICMSValidator
    {
        Host Validate(Host h);
    }
}
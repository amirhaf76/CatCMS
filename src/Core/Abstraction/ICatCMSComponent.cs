using Core.Enums;

namespace Core.Abstraction
{
    public interface ICatCMSComponent : IStorable, IGeneratable
    {
        public Guid Id { get; set; }

        public CatCMSComponentType Type { get; }
    }
}
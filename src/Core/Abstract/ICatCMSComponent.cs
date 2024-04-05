using System.Text.Json;

namespace Core.Abstract
{
    public interface ICatCMSComponent
    {
        public Guid Id { get; set; }

        public CatCMSComponentType Type { get; }

        public JsonElement Store();
    }

    public enum CatCMSComponentType
    {
        CarouselCatComponent
    }
}
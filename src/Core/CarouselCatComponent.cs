using System.Diagnostics.CodeAnalysis;
using Core.Enums;

namespace Core
{
    public class CarouselCatComponent : BaseCatComponent
    {
        private List<object> Images { get; set; } = new List<object>();

        public object AddImage(object image)
        {
            Images.Add(image);

            return this;
        }

        public object RemoveImage(object image)
        {
            Images.Remove(image);

            return this;
        }

        public override string Generate()
        {
            return "<p>CarouselCatComponent</p>";
        }

        public override CatCMSComponentType Type => CatCMSComponentType.CarouselCatComponent;
    }
}
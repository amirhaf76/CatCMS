﻿namespace CMSCore.Component
{
    public class CarouselCatComponent : BaseCatComponent
    {
        private List<object> Images { get; set; } = new List<object>();

        public string Title => "ddddd";

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

        public override string GenerateCode()
        {
            return "Hello {{ Title }}";
            //return "<p>CarouselCatComponent</p>";
        }

    }
}
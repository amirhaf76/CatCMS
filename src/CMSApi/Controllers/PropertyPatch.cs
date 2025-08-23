using System.Text.Json;

namespace CMSApi.Controllers
{
    public class PropertyPatch 
    {
        public string Name { get; set; } = string.Empty;

        public int Number { get; set; }

        public int? Value { get; set; }
    }
}
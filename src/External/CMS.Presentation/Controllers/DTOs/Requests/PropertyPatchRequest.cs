using System.Text.Json;

namespace CMS.Presentation.Controllers.DTOs.Requests
{
    public class PropertyPatchRequest 
    {
        public string Name { get; set; } = string.Empty;

        public int Number { get; set; }

        public int? Value { get; set; }
    }
}
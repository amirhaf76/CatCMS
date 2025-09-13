namespace CMS.Presentation.Controllers.DTOs.Requests
{
    public class JsonPatchRequest<T>
    {
        public T? Data { get; set; }

        public IEnumerable<string> PatchedProperties { get; set; } = [];
    }
}
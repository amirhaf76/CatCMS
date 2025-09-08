using CMSApi.Controllers;

namespace CMSApi
{
    public class JsonPatchRequest<T>
    {
        public T? Data { get; set; }

        public IEnumerable<string> PatchedProperties { get; set; } = Enumerable.Empty<string>();
    }
}
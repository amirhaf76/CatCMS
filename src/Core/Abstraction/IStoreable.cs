using System.Text.Json;

namespace Core.Abstraction
{
    public interface IStorable
    {
        public JsonElement Store();
    }
}
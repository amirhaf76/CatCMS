using System.Text.Json;

namespace CMSCore.Abstraction
{
    public interface IStorable
    {
        public JsonElement Store();
    }
}
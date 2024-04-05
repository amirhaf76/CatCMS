using System.Text.Json;
using Core.Abstract;

namespace Core
{
    public abstract class BaseCatComponent : ICatCMSComponent
    {
        private readonly List<BaseCatComponent> _components = new();

        public Guid Id { get; set; }

        public abstract CatCMSComponentType Type { get; }

        public IEnumerable<BaseCatComponent> GetComponents()
        {
            return _components;
        }

        public BaseCatComponent AddComponent(BaseCatComponent component)
        {
            _components.Add(component);

            return this;
        }

        public BaseCatComponent AddComponents(IEnumerable<BaseCatComponent> components)
        {
            _components.AddRange(components);

            return this;
        }

        public BaseCatComponent RemoveComponent(BaseCatComponent component)
        {
            _components.Remove(component);

            return this;
        }

        public BaseCatComponent RemoveComponents(IEnumerable<BaseCatComponent> components)
        {
            foreach (var component in components)
            {
                RemoveComponent(component);
            }

            return this;
        }


        public JsonElement Store()
        {
            throw new NotImplementedException();
        }
    }
}
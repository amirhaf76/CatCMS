using Fluid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMSCore.Component
{
	public class ComponentContainer
	{
		private string _liquidDirectory;
		private IDictionary<Type, string> _templateComponentMap;
        private ITemplateProvider _templateProvider;

        public ComponentContainer(string liquidDirectory, ITemplateProvider templateProvider)
        {
            _liquidDirectory = liquidDirectory;
            _templateComponentMap = new Dictionary<Type, string>();
            _templateProvider = templateProvider;
        }

        public TemplateOptions GetAllComponentSources()
		{
			var componentTypes = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.IsAssignableTo(typeof(BaseComponent)));

			var option = new TemplateOptions();

			foreach (var component in componentTypes)
			{
				option.MemberAccessStrategy.Register(component);
			}

            return option;
		}


		public string GetTemplate<T>() where T: BaseComponent
		{
			var type = typeof(T);

			if (_templateComponentMap.TryGetValue(type, out string? template))
			{
				return template;
			}

            return ReadTemplateFromFileAndAddToMapping(type);

        }

        public async Task<string> GetTemplateAsync<T>() where T : BaseComponent
        {
            var type = typeof(T);

            if (_templateComponentMap.TryGetValue(type, out string? template))
            {
                return template;
            }

            return await ReadTemplateFromFileAndAddToMappingAsync(type);
        }


        private async Task<string> ReadTemplateFromFileAndAddToMappingAsync(Type type)
        {
            try
            {
				var path = GetTemplatePath(type);

                using var templateFile = File.OpenText(path);

                var source = await templateFile.ReadToEndAsync();

                _templateComponentMap.Add(type, source);

                return source;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        private string ReadTemplateFromFileAndAddToMapping(Type type)
        {
            try
            {
                var path = GetTemplatePath(type);

                using var templateFile = File.OpenText(path);

                var source = templateFile.ReadToEnd();

                _templateComponentMap.Add(type, source);

                return source;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
        }

        private string GetTemplatePath(Type type)
        {
            return Path.Combine(_liquidDirectory, _templateProvider.GetFileName(type));
        }
    }

    public interface ITemplateProvider
    {
        string GetFileName(Type type);
    }

    public class DefaultTemplateProvider : ITemplateProvider
    {
        public string GetFileName(Type type)
        {
            var index = type.Name.LastIndexOf("Component");

            var name = char.ToLower(type.Name[0]) + type.Name[1..index];

            return $"{name}.liquid";
        }
    }
}

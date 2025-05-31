using Fluid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CMSCore.Component
{
	public class ComponentContainer
	{
		public void GetAllComponentSources()
		{
			var componentTypes = Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.Where(type => type.IsAssignableTo(typeof(BaseComponent)));

			var option = new TemplateOptions();

			foreach (var component in componentTypes)
			{
				new TemplateOptions().MemberAccessStrategy.Register(component);
			}


		}
	}
}

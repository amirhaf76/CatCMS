using Core.Abstraction;
using Core.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Core
{

    public class Page 
    {
        private readonly List<ICatCMSComponent> _components;
        private ILayout _layout;


        public string Title { get; private set; }

        public Guid Id { get; }

        public IEnumerable<ICatCMSComponent> Components
        {
            get
            {
                return _components;
            }
        }

        public ILayout Layout { get => _layout; }


        public Page(string title, Guid id)
        {
            Id = id;
            Title = title;
            _components = new List<ICatCMSComponent>();
            _layout = new StackLayout();
        }

        public Page(string title) : this(title, Guid.NewGuid())
        {

        }


        public Page EditTitle(string newTitle)
        {
            Title = newTitle ?? throw new NullTitleException();

            return this;
        }

        public ICatCMSComponent AddComponent(ICatCMSComponent aComponent)
        {
            _components.Add(aComponent);

            return aComponent;
        }

        public ILayout SetLayout(ILayout layout)
        {
            _layout = layout;

            return _layout;
        }
    }




}
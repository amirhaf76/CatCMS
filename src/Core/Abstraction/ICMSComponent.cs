namespace CMSCore.Abstraction
{
    public interface ICMSComponent : IStorable, IGeneratableToCode
    {
        public Guid Id { get; set; }

     
    }
}
namespace CMSCore.Abstraction
{
    public interface ICMSDirector
    {
        void Prepare();
        ICMSBuilder Builder { get; }
    }
}
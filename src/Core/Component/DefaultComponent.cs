namespace CMSCore.Component
{
    public class DefaultComponent : BaseCatComponent
    {
        public override string GenerateCode()
        {
            return @$"<p id =""{Id}"">{nameof(DefaultComponent)}</p>";
        }
    }
}
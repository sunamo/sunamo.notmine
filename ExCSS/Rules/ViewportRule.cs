
namespace ExCSS
{
    public sealed class ViewportRule : DeclarationRule
    {
        public ViewportRule(StylesheetParser parser)
            : base(RuleType.Viewport, RuleNames.ViewPort, parser)
        {
        }

        protected override Property CreateNewProperty(string name)
        {
            return PropertyFactory.Instance.CreateViewport(name);
        }
    }
}
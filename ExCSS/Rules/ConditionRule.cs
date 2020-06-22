
namespace ExCSS
{
    public abstract class ConditionRule : GroupingRule
    {
        public ConditionRule(RuleType type, StylesheetParser parser)
            : base(type, parser)
        {
        }
    }
}
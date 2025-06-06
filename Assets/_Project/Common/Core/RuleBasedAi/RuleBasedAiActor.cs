using Project.Core.GameCycle;
using Project.Core.Services;

namespace Project.Core.RuleBasedAi
{
    public class RuleBasedAiActor : IAiActor, IUpdateable
    {
        private readonly IRule[] _rules;

        public RuleBasedAiActor(params IRule[] rules) =>
            _rules = rules;

        public void Update()
        {
            foreach (IRule rule in _rules)
            {
                if (rule.CanExecute)
                {
                    rule.Execute();
                    return;
                }
            }
        }
    }
}

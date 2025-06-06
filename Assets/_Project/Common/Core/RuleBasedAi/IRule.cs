namespace Project.Core.RuleBasedAi
{
    public interface IRule
    {
        bool CanExecute {  get; }
        void Execute();
    }
}

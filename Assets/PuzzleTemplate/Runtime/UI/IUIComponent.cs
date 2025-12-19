namespace PuzzleTemplate.Runtime
{
    public interface IUIComponent : IState
    {
        string Key { get; }
    }
}
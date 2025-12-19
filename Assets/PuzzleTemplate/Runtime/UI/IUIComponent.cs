namespace PuzzleTemplate.Runtime.UI
{
    public interface IUIComponent : IState
    {
        string Key { get; }
    }
}
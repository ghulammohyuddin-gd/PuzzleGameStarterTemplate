namespace PuzzleTemplate.Runtime
{
    public interface ICommand
    {
        void Execute();

        void Undo();
    }
}
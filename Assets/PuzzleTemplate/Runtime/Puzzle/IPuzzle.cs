namespace PuzzleTemplate.Runtime
{
    public interface IPuzzle
    {
        void Initialise();

        void Reset();
    }

    public interface IPuzzle<TData> : IPuzzle
        where TData : IPuzzleData
    {
        TData Data { get; }

        void SetData(TData data);
    }
}
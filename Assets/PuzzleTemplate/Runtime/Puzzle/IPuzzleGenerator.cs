namespace PuzzleTemplate.Runtime
{
    public interface IPuzzleGenerator
    {
        IPuzzle Generate(IPuzzleData data);
    }
}
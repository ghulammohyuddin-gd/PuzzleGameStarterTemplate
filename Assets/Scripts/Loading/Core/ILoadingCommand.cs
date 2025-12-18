using System.Collections;

namespace PuzzleGameStarterTemplate.Loading.Core
{
    public interface ILoadingCommand
    {
        IEnumerator Execute();
    }
}

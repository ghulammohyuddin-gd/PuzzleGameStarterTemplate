using UnityEngine;
using System.Collections;

namespace PuzzleGameStarterTemplate.Loading.Core
{
    public abstract class LoadingCommandBase : MonoBehaviour, ILoadingCommand
    {
        public abstract IEnumerator Execute();
    }
}

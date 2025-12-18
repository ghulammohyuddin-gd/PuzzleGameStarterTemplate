using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public abstract class LoadingStepBase : MonoBehaviour
    {
        public abstract UniTask ExecuteAsync(CancellationToken cToken = default);
    }
}

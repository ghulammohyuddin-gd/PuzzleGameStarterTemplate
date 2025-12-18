using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public class ServicesLoadingStep : LoadingStepBase
    {
        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log("Initializing services...");
            return UniTask.Delay(500, cancellationToken: cToken);
        }

    }
}

using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
{
    public class LoadServicesCommand : LoadingStepBase
    {
        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log("Initializing services...");
            return UniTask.Delay(500, cancellationToken: cToken);
        }

    }
}

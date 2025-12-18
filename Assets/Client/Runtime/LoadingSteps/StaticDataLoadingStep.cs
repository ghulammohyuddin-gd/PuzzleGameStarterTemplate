using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public class StaticDataLoadingStep : LoadingStepBase
    {
        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log("Loading static data...");

            return UniTask.Delay(500, cancellationToken: cToken);
        }

    }
}

using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using Client.Runtime.Persistance;
using UnityEngine;

namespace Client.Runtime
{
    public class PlayerProgressLoadingStep : LoadingStepBase
    {

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log("Loading player progress...");

            ProgressManager.LoadLevel();
            return UniTask.CompletedTask;
        }

    }
}

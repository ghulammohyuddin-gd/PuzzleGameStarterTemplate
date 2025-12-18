using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using Template.Runtime.Persistance;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
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

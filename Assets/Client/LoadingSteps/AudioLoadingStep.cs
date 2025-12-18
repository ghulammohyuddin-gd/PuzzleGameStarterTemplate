using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
{
    public class AudioLoadingStep : LoadingStepBase
    {

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log("Loading audio system...");
            return UniTask.CompletedTask;
        }

    }
}

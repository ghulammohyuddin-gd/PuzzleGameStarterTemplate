using System.Collections;
using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
{
    public class LoadStaticDataCommand : LoadingStepBase
    {
        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log("Loading static data...");

            return UniTask.Delay(500, cancellationToken: cToken);
        }

    }
}

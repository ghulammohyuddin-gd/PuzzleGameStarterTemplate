using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
{
    public class LoadStubCommand : LoadingStepBase
    {
        [SerializeField] private string description;

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            Debug.Log($"Stub: {description}");

            return UniTask.Delay(500, cancellationToken: cToken);
        }

    }
}

using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace PuzzleTemplate.Runtime
{
    public class AppLoader : MonoBehaviour
    {
        [Header("(Order Matters)")]
        [SerializeField] protected LoadingStepBase[] _steps;

        protected virtual void Start()
        {
            UniTask.Void(ExecuteStepsAsync, this.GetCancellationTokenOnDestroy());
        }

        protected virtual async UniTaskVoid ExecuteStepsAsync(CancellationToken cToken = default)
        {
            var total = _steps.Length;

            for (int i = 0; i < total; i++)
            {
                await _steps[i].ExecuteAsync(cToken);

                var progress = (float)(i + 1) / total;

                EventBus.Raise(new LoadingStepExecutedEvent(progress));
            }
        }
    }
}

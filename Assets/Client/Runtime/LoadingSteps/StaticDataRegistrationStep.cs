using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public class StaticDataRegistrationStep : LoadingStepBase
    {
        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            ContentRegistry.Register<GameSettingsData>("GameSettingsData");
            return UniTask.CompletedTask;
        }
    }
}

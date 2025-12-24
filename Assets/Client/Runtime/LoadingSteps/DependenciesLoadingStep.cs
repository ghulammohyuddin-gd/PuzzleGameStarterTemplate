using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;

namespace Client.Runtime
{
    public class DependenciesLoadingStep : LoadingStepBase
    {
        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            BindDataService();
            return UniTask.CompletedTask;
        }

        private void BindDataService()
        {
            var dataService = new DataService();
            Locator.Register<IDataService>(dataService);
            Locator.Register<IContentLoader>(dataService);
        }
    }
}

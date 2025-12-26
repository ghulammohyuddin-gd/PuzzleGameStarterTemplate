using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public class DependenciesLoadingStep : LoadingStepBase
    {
        [Header("Dependencies")]
        [SerializeField] protected GameObject _winConditionCheckerRef;
        [SerializeField] protected GameObject _puzzleGeneratorRef;
        [SerializeField] protected GameObject _puzzleDataProviderRef;

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            BindDataService();
            BindPuzzleDependencies();
            return UniTask.CompletedTask;
        }

        private void BindDataService()
        {
            var dataService = new DataService();
            Locator.Register<IDataService>(dataService);
            Locator.Register<IContentLoader>(dataService);
        }

        private void BindPuzzleDependencies()
        {
            Locator.Register(_winConditionCheckerRef.GetComponent<IWinConditionChecker>());
            Locator.Register(_puzzleGeneratorRef.GetComponent<IPuzzleGenerator>());
            Locator.Register(_puzzleDataProviderRef.GetComponent<IPuzzleDataProvider>());
        }
    }
}

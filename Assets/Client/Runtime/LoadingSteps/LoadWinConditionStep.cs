using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime
{
    public class LoadWinConditionStep : LoadingStepBase
    {
        [SerializeField] private List<WinCondition> _winConditions;

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            var dataService = Locator.Get<IDataService>();
            var gameSettings = dataService.GetAllData<GameSettingsData>().First();
            var winContion = _winConditions.Find(x => x.Constraint == gameSettings.WinConstraint);
            Locator.Register(winContion.ConditionChecker);
            return UniTask.CompletedTask;
        }
    }
}

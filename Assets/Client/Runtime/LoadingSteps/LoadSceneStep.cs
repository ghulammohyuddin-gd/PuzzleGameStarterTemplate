using System.Threading;
using Cysharp.Threading.Tasks;
using PuzzleTemplate.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Client.Runtime
{
    public class LoadSceneStep : LoadingStepBase
    {
        [SerializeField] private string _name;

        public override UniTask ExecuteAsync(CancellationToken cToken = default)
        {
            SceneManager.LoadScene(_name);
            return UniTask.CompletedTask;
        }
    }
}

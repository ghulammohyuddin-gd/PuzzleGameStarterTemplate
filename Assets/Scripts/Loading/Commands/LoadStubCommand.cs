using System.Collections;
using PuzzleGameStarterTemplate.Loading.Core;
using UnityEngine;

namespace PuzzleGameStarterTemplate.Loading.Commands
{
    public class LoadStubCommand : LoadingCommandBase
    {
        [SerializeField] private string description;

        public override IEnumerator Execute()
        {
            Debug.Log($"Stub: {description}");
            yield return new WaitForSeconds(0.3f);
        }
    }
}

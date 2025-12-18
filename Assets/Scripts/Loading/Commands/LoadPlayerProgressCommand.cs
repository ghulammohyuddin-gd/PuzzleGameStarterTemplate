using System.Collections;
using PuzzleGameStarterTemplate.Loading.Core;
using PuzzleGameStarterTemplate.Persistance;
using UnityEngine;

namespace PuzzleGameStarterTemplate.Loading.Commands
{
    public class LoadPlayerProgressCommand : LoadingCommandBase
    {
        public override IEnumerator Execute()
        {
            Debug.Log("Loading player progress...");

            ProgressManager.LoadLevel();

            // Simulate async load / future backend hook
            yield return null;
        }
    }
}

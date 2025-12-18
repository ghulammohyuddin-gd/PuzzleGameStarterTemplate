using System.Collections;
using PuzzleGameStarterTemplate.Loading.Core;
using UnityEngine;

namespace PuzzleGameStarterTemplate.Loading.Commands
{
    public class LoadServicesCommand : LoadingCommandBase
    {
        public override IEnumerator Execute()
        {
            Debug.Log("Initializing services...");
            yield return new WaitForSeconds(0.5f); // stub
        }
    }
}

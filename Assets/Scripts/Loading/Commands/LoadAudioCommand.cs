using System.Collections;
using PuzzleGameStarterTemplate.Audio;
using PuzzleGameStarterTemplate.Loading.Core;
using UnityEngine;

namespace PuzzleGameStarterTemplate.Loading.Commands
{
    public class LoadAudioCommand : LoadingCommandBase
    {
        public override IEnumerator Execute()
        {
            Debug.Log("Loading audio system...");

            AudioManager.Instance.Initialize();

            yield return null;
        }
    }
}

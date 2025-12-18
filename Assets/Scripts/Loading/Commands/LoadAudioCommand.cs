using System.Collections;
using Template.Runtime.Audio;
using Template.Runtime.Loading.Core;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
{
    public class LoadAudioCommand : LoadingCommandBase
    {
        public override IEnumerator Execute()
        {
            Debug.Log("Loading audio system...");

            yield return null;
        }
    }
}

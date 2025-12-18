using System.Collections;
using Template.Runtime.Loading.Core;
using Template.Runtime.Persistance;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
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

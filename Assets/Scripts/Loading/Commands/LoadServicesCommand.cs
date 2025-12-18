using System.Collections;
using Template.Runtime.Loading.Core;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
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

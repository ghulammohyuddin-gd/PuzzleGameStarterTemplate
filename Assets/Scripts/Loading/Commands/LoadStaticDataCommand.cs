using System.Collections;
using Template.Runtime.Loading.Core;
using UnityEngine;

namespace Template.Runtime.Loading.Commands
{
    public class LoadStaticDataCommand : LoadingCommandBase
    {
        public override IEnumerator Execute()
        {
            Debug.Log("Loading static data...");
            yield return new WaitForSeconds(0.5f); // stub
        }
    }
}

using UnityEngine;
using System.Collections;

namespace Template.Runtime.Loading.Core
{
    public abstract class LoadingCommandBase : MonoBehaviour, ILoadingCommand
    {
        public abstract IEnumerator Execute();
    }
}

using UnityEngine;
using System.Collections;

public abstract class LoadingCommandBase : MonoBehaviour, ILoadingCommand
{
    public abstract IEnumerator Execute();
}

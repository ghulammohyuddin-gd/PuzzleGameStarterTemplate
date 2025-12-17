using System.Collections;
using UnityEngine;

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

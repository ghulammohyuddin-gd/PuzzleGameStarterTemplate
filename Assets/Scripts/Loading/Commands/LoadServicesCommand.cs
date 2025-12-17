using System.Collections;
using UnityEngine;

public class LoadServicesCommand : LoadingCommandBase
{
    public override IEnumerator Execute()
    {
        Debug.Log("Initializing services...");
        yield return new WaitForSeconds(0.5f); // stub
    }
}

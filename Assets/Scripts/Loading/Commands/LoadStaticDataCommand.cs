using System.Collections;
using UnityEngine;

public class LoadStaticDataCommand : LoadingCommandBase
{
    public override IEnumerator Execute()
    {
        Debug.Log("Loading static data...");
        yield return new WaitForSeconds(0.5f); // stub
    }
}

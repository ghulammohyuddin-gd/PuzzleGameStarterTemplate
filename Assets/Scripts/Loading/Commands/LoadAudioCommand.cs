using System.Collections;
using UnityEngine;

public class LoadAudioCommand : LoadingCommandBase
{
    public override IEnumerator Execute()
    {
        Debug.Log("Loading audio system...");

        AudioManager.Instance.Initialize();

        yield return null;
    }

}

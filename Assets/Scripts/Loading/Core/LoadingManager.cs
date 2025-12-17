using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadingManager : MonoBehaviour
{
    [Header("Loading Commands (Order Matters)")]
     [SerializeField] private List<LoadingCommandBase> commands;

    [Header("UI")]
    [SerializeField] private LoadingUIController ui;

    private void Start()
    {
        StartCoroutine(ExecuteCommands());
    }

    private IEnumerator ExecuteCommands()
    {
        int total = commands.Count;

        for (int i = 0; i < total; i++)
        {
            yield return StartCoroutine(commands[i].Execute());

            float progress = (float)(i + 1) / total;
            ui.UpdateProgress(progress);
        }

        ui.OnLoadingComplete();
    }
}

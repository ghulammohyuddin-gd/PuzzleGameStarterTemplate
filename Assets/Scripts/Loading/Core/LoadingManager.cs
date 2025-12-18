using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Template.Runtime.Loading.UI;

namespace Template.Runtime.Loading.Core
{
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
}

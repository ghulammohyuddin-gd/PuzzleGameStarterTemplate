using PuzzleTemplate.Runtime.UI;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class SettingsView : UIComponent
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("SettingsView: OnEnter");
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("SettingsView: OnExit");
        }
    }
}

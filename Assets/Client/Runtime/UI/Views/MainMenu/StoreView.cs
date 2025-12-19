using PuzzleTemplate.Runtime.UI;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class StoreView : UIComponent
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("StoreView: OnEnter");
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("StoreView: OnExit");
        }
    }
}

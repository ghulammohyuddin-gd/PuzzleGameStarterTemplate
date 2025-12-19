using PuzzleTemplate.Runtime;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class MapView : UIComponent
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("MapView: OnEnter");
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("MapView: OnExit");
        }
    }
}

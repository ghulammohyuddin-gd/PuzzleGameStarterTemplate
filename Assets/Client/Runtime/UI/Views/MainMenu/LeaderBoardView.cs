using PuzzleTemplate.Runtime.UI;
using UnityEngine;

namespace Client.Runtime.UI
{
    public sealed class LeaderBoardView : UIComponent
    {
        public override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("LeaderBoardView: OnEnter");
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("LeaderBoardView: OnExit");
        }
    }
}

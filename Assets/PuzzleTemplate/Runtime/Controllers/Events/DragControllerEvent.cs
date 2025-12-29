namespace PuzzleTemplate.Runtime
{
    public enum DragState { Started, Ended }

    public readonly struct DragControllerEvent : IEvent
    {
        public readonly ISceneEntity SceneEntity;
        public readonly DragState DragState;

        public DragControllerEvent(ISceneEntity sceneEntity, DragState dragState)
        {
            SceneEntity = sceneEntity;
            DragState = dragState;
        }
    }
}
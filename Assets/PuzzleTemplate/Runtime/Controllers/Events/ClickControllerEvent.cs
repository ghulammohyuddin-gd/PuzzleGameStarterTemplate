namespace PuzzleTemplate.Runtime
{
    public readonly struct ClickControllerEvent : IEvent
    {
        public readonly ISceneEntity SceneEntity;

        public ClickControllerEvent(ISceneEntity sceneEntity) => SceneEntity = sceneEntity;
    }
}
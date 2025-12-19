namespace PuzzleTemplate.Runtime
{
    public interface IStateMachine
    {
        IState CurrentState { get; }

        bool TryRegisterState(IState state);

        void SwitchState(IState newState);

        void Stop();

        void Clear();
    }
}
namespace PuzzleTemplate.Runtime
{
    public interface IStateMachine
    {
        IState CurrentState { get; }

        bool TryRegisterState<TState>(TState state) where TState : IState;

        void SwitchState<TState>(TState state) where TState : IState;

        void Reset();
    }
}
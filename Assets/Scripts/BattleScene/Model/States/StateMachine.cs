using Assets.Scripts.BattleScene.Model.States.Base;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class StateMachine : IStateMachine
    {
        public StateBase CurrentState { get; set; }

        public void Initialize(StateBase startState)
        {
            CurrentState = startState;
            ChangeStateInternal(startState);
        }

        public void ChangeState(StateBase newState)
        {
            CurrentState.Exit();
            ChangeStateInternal(newState);
        }

        private void ChangeStateInternal(StateBase newState)
        {
            CurrentState = newState;
            CurrentState.Enter();
        }
    }

    internal interface IStateMachine
    {
        StateBase CurrentState { get; set; }

        void Initialize(StateBase startState);

        void ChangeState(StateBase newState);
    }
}
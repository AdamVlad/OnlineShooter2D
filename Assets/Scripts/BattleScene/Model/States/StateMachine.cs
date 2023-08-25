using Assets.Scripts.BattleScene.Model.States.Base;
using Assets.Scripts.BattleScene.Model.States.Interfaces;

namespace Assets.Scripts.BattleScene.Model.States
{
    internal class StateMachine : IStateMachine
    {
        public StateBase CurrentState { get; private set; }
        public StateBase PreviousState { get; private set; }

        public void Initialize(StateBase startState)
        {
            CurrentState = startState;
            PreviousState = startState;
            ChangeStateInternal(startState);
        }

        public void ChangeState(StateBase newState)
        {
            if (CurrentState == newState) return;

            CurrentState.Exit();
            ChangeStateInternal(newState);
        }

        private void ChangeStateInternal(StateBase newState)
        {
            PreviousState = CurrentState;
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
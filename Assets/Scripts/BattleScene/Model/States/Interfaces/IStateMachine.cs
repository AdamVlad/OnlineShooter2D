using Assets.Scripts.BattleScene.Model.States.Base;

namespace Assets.Scripts.BattleScene.Model.States.Interfaces
{
    internal interface IStateMachine
    {
        StateBase CurrentState { get; }
        StateBase PreviousState { get; }

        void Initialize(StateBase startState);

        void ChangeState(StateBase newState);
    }
}
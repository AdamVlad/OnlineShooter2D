namespace Assets.Scripts.BattleScene.Model.Abilities.Interfaces
{
    internal interface ITakeCoinsAbility
    {
        float CurrentCoins { get; }
        void TakeCoin(float price);
    }
}
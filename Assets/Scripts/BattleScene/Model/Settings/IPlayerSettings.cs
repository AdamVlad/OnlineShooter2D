using Assets.Scripts.BattleScene.ViewModel;

namespace Assets.Scripts.BattleScene.Model.Settings
{
    internal interface IPlayerSettings
    {
        float WalkSpeed { get; }
        BulletViewModel Bullet { get; }
        float ShootPower { get; }
        float ShootDamage{ get; }
        float ShootDelay { get; }
        string InputAxisX { get; }
        string InputAxisY { get; }
        string InputAxisXHatch { get; }
        string InputAxisYHatch { get; }
        string Velocity { get; }
        string ShootTrigger { get; }
    }
}
using Assets.Scripts.BattleScene.ViewModel;
using UnityEngine;

namespace Assets.Scripts.BattleScene.Model.Settings
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/PlayerSettings")]
    internal class PlayerSettings : ScriptableObject, IPlayerSettings
    {
        [Space]
        
        [SerializeField] private float _walkSpeed = 2f;
        public float WalkSpeed => _walkSpeed;

        [Space]
        [Header("Shoot Settings")]

        [SerializeField] private BulletViewModel _bullet;
        public BulletViewModel Bullet => _bullet;

        [SerializeField] private float _shootPower = 0.2f;
        public float ShootPower => _shootPower;

        [SerializeField] private float _shootDamage = 25f;
        public float ShootDamage => _shootDamage;

        [SerializeField] private float _shootDelay = 0.6f;
        public float ShootDelay => _shootDelay;

        [Space]
        [Header("Animator Parameters")]

        [SerializeField] private string _inputAxisX = "x";
        public string InputAxisX => _inputAxisX;

        [SerializeField] private string _inputAxisY = "y";
        public string InputAxisY => _inputAxisY;

        [SerializeField] private string _inputAxisXHatch = "x'";
        public string InputAxisXHatch => _inputAxisXHatch;

        [SerializeField] private string _inputAxisYHatch = "y'";
        public string InputAxisYHatch => _inputAxisYHatch;

        [SerializeField] private string _velocity = "Velocity";
        public string Velocity => _velocity;

        [SerializeField] private string _shootTrigger = "Shoot";
        public string ShootTrigger => _shootTrigger;
    }
}

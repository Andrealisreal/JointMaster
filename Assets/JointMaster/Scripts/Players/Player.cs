using JointMaster.Scripts.Catapults;
using JointMaster.Scripts.Players.Inputs;
using JointMaster.Scripts.Swings;
using UnityEngine;

namespace JointMaster.Scripts.Players
{
    public class Player : MonoBehaviour
    {
        private PlayerInput _input;
        private PlayerConfig _config;
        private Swing _swing;
        private Catapult _catapult;

        private void Awake()
        {
            _input = new PlayerInput();
            _input.Initialize();
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.SwingClicked += OnSwing;
            _input.ChargeClicked += OnCharge;
            _input.FireClicked += OnFire;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.SwingClicked -= OnSwing;
            _input.ChargeClicked -= OnCharge;
            _input.FireClicked -= OnFire;
        }

        public void Initialize(Swing swing, Catapult catapult, PlayerConfig config)
        {
            _swing = swing;
            _config = config;
            _catapult = catapult;
        }

        private void OnSwing() =>
            _swing.SetForce(_config.Force);

        private void OnFire() =>
            _catapult.Fire();

        private void OnCharge() =>
            _catapult.Charge();
    }
}
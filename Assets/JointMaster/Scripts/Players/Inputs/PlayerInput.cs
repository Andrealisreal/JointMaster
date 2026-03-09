using System;
using UnityEngine.InputSystem;

namespace JointMaster.Scripts.Players.Inputs
{
    public class PlayerInput
    {
        public event Action SwingClicked;
        public event Action FireClicked;
        public event Action ChargeClicked;

        private InputActions _inputAction;

        public void Initialize()
        {
            _inputAction = new InputActions();

            _inputAction.Player.Swing.performed += OnSwing;
            _inputAction.Player.Fire.performed += OnFire;
            _inputAction.Player.Charge.performed += OnCharge;
        }

        public void Enable() =>
            _inputAction.Enable();

        public void Disable() =>
            _inputAction.Disable();

        private void OnSwing(InputAction.CallbackContext context) =>
            SwingClicked?.Invoke();

        private void OnFire(InputAction.CallbackContext context) =>
            FireClicked?.Invoke();

        private void OnCharge(InputAction.CallbackContext context) =>
            ChargeClicked?.Invoke();
    }
}
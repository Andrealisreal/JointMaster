using JointMaster.Scripts.Catapults.Projectiles;
using System.Collections;
using UnityEngine;

namespace JointMaster.Scripts.Catapults
{
    [RequireComponent(typeof(SpringJoint))]
    [RequireComponent(typeof(HingeJoint))]
    public class Catapult : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ProjectileSpawner _spawner;
        [SerializeField] private SpringJoint _springJointFire;
        [SerializeField] private SpringJoint _springJointCharge;
        
        [SerializeField] private float _chargeSpringValue = 50f;
        [SerializeField] private float _fireSpringValue = 50f;
        [SerializeField] private float _reloadTime = 1.5f;

        private bool _isReloading;
        private bool _isReadyToFire;
        private Coroutine _reloadRoutine;

        private void Start() =>
            Charge();

        public void Fire()
        {
            if (_isReloading || _isReadyToFire == false) 
                return;

            _rigidbody.WakeUp();
            _springJointCharge.spring = 0f;
            _springJointFire.spring = _fireSpringValue;
            _isReadyToFire = false;
        }

        public void Charge()
        {
            if (_isReloading || _isReadyToFire) 
                return;

            if (_reloadRoutine != null) 
                StopCoroutine(_reloadRoutine);
            
            _reloadRoutine = StartCoroutine(ReloadRoutine());
        }

        private IEnumerator ReloadRoutine()
        {
            _isReloading = true;
            _isReadyToFire = false;

            _rigidbody.WakeUp();
            _springJointFire.spring = 0f;
            _springJointCharge.spring = 0f;

            var elapsed = 0f;
            
            while (elapsed < _reloadTime)
            {
                elapsed += Time.deltaTime;
                var t = Mathf.Clamp01(elapsed / _reloadTime);
                
                _springJointCharge.spring = Mathf.Lerp(0f, _chargeSpringValue, t);

                yield return null;
            }
            
            _springJointCharge.spring = _chargeSpringValue;
            _spawner.Spawn();

            _isReloading = false;
            _isReadyToFire = true;
        }
    }
}
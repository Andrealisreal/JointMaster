using JointMaster.Scripts.Catapults.Projectiles;
using UnityEngine;

namespace JointMaster.Scripts.Catapults
{
    [RequireComponent(typeof(SpringJoint))]
    [RequireComponent(typeof(HingeJoint))]
    public class Catapult : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private ProjectileSpawner _spawner;
        
        private Transform _startPosition;

        private void Awake()
        {
            _rigidbody.isKinematic = true;
            _startPosition = transform;
            _spawner.Spawn();
        }

        public void Fire() =>
            _rigidbody.isKinematic = false;

        public void Charge()
        {
            _rigidbody.isKinematic = true;
            transform.position = _startPosition.position;
            _spawner.Spawn();
        }
    }
}
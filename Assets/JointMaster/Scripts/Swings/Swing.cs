using UnityEngine;

namespace JointMaster.Scripts.Swings
{
    [RequireComponent(typeof(HingeJoint))]
    public class Swing : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        public void SetForce(float force) =>
            _rigidbody.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}

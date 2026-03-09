using UnityEngine;

namespace JointMaster.Scripts.Catapults.Projectiles
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private Projectile _prefab;
        [SerializeField] private Transform _spawnPoint;

        public void Spawn() =>
            Instantiate(_prefab, _spawnPoint);
    }
}

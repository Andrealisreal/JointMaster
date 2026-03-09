using JointMaster.Scripts.Catapults;
using JointMaster.Scripts.Players;
using JointMaster.Scripts.Swings;
using UnityEngine;

namespace JointMaster.Scripts
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Swing _swing;
        [SerializeField] private Catapult _catapult;

        private void Awake() =>
            _player.Initialize(_swing, _catapult, _playerConfig);
    }
}
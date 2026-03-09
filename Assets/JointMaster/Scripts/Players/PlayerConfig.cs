using UnityEngine;

namespace JointMaster.Scripts.Players
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Scriptable Objects/PlayerConfig")]
    public class PlayerConfig : Config
    {
        [field: SerializeField] public float Force { get; private set; }
    }
}

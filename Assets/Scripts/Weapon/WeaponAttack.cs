using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class WeaponAttack : MonoBehaviour
    {
        public abstract bool Attack(Vector3 position, Vector3 direction);
    }
}

using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public interface IWeaponAimedAttack
    {
        public void SetShootPositionAndDirection(Vector3 position, Vector3 direction);
        public bool AimedAttack();
    }
}

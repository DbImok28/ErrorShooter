using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class WeaponAimedAttack : MonoBehaviour, IWeaponAimedAttack
    {
        [SerializeField] private WeaponAttack WeaponAttackDecorator;

        private Vector3 AttackPosition;
        private Vector3 AttackDirection;

        public WeaponAimedAttack(WeaponAttack subWeaponAttack)
        {
            WeaponAttackDecorator = subWeaponAttack;
        }

        public void SetShootPositionAndDirection(Vector3 position, Vector3 direction)
        {
            AttackPosition = position;
            AttackDirection = direction;
        }

        public bool AimedAttack()
        {
            return WeaponAttackDecorator.Attack(AttackPosition, AttackDirection);
        }
    }
}

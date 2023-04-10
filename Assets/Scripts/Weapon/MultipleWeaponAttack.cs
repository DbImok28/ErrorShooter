using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class MultipleWeaponAttack : WeaponAttack
    {
        [SerializeField] private WeaponAttack WeaponAttackDecorator;
        [SerializeField] private float Spread = 5.0f;
        [SerializeField] private int ShootCount = 8;

        Vector3 AddNoiseOnAngle(float min, float max)
        {
            float xNoise = Random.Range(min, max);
            float yNoise = Random.Range(min, max);
            float zNoise = Random.Range(min, max);

            Vector3 noise = new
            (
              Mathf.Sin(2 * Mathf.PI * xNoise / 360),
              Mathf.Sin(2 * Mathf.PI * yNoise / 360),
              Mathf.Sin(2 * Mathf.PI * zNoise / 360)
            );
            return noise;
        }

        public override bool Attack(Vector3 position, Vector3 direction)
        {
            for (int i = 0; i < ShootCount; ++i)
            {
                if (!WeaponAttackDecorator.Attack(position, direction + AddNoiseOnAngle(-Spread, Spread))) return false;
            }
            return true;
        }
    }
}

using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class TriggerPullWithDelay : TriggerPull
    {
        [SerializeField] private float FireRate = 120;
        private bool DelayComplite = true;
        private bool IsPressed = false;


        public TriggerPullWithDelay(WeaponAimedAttack aimedAttack, float fireRate = 120) : base(aimedAttack)
        {
            FireRate = fireRate;
        }

        public override void Press()
        {
            IsPressed = true;
            Fire();
        }

        public override void Release()
        {
            DelayComplite = true;
            IsPressed = false;
        }

        private void Update()
        {
            if (IsPressed)
            {
                Fire();
            }
        }

        public void Fire()
        {
            if (DelayComplite)
            {
                AimedAttack.AimedAttack();
                DelayComplite = false;
                StartCoroutine(FireRateCoroutine());
            }
        }

        private IEnumerator FireRateCoroutine()
        {
            yield return new WaitForSeconds(60.0f / FireRate);
            DelayComplite = true;
        }
    }
}

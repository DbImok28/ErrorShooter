using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public abstract class TriggerPull : MonoBehaviour, ITriggerPull
    {
        [SerializeField] protected WeaponAimedAttack AimedAttack;

        public TriggerPull(WeaponAimedAttack aimedAttack)
        {
            AimedAttack = aimedAttack;
        }

        public abstract void Press();
        public abstract void Release();
    }
}

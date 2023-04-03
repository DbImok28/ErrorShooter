using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class MagazineWeaponAttack : WeaponAttack, IWeaponMagazine
    {
        [SerializeField] private WeaponAttack WeaponAttackDecorator;
        [SerializeField] private int MagazineCapacity = 30;

        // TODO:Mark private
        public int AmmoInMagazine = 0;
        public int AmmoAmount = 0;

        public MagazineWeaponAttack(WeaponAttack subWeaponAttack, int magazineCapacity = 30)
        {
            WeaponAttackDecorator = subWeaponAttack;
            MagazineCapacity = magazineCapacity;
        }

        public override bool Attack(Vector3 position, Vector3 direction)
        {
            if (AmmoInMagazine == 0)
            {
                print("No ammo - press Enter to reload");
                return false;
            }
            --AmmoInMagazine;
            WeaponAttackDecorator.Attack(position, direction);
            return true;
        }

        public int ChargeAmmo(int amount)
        {
            AmmoInMagazine += amount;
            if (AmmoInMagazine > MagazineCapacity)
            {
                var dif = AmmoInMagazine - MagazineCapacity;
                AmmoInMagazine = MagazineCapacity;
                return dif;
            }
            return 0;
        }

        public void Reload()
        {
            AmmoAmount = ChargeAmmo(AmmoAmount);
        }
    }
}

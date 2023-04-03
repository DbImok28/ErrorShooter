namespace Assets.Scripts.Weapon
{
    public interface IWeaponMagazine
    {
        void Reload();
        int ChargeAmmo(int amount);
    }
}

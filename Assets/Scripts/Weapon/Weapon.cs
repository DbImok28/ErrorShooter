using Assets.Scripts.Weapon;
using UnityEngine;

public class Weapon : MonoBehaviour, ITriggerPull
{
    public GameObject ShootSource;
    public TriggerPull[] TriggerPulls;
    public WeaponAimedAttack Aim;
    public MagazineWeaponAttack Magazine;

    private int CurrentTriggerPull = 0;

    public void SwitchTrigger(int index)
    {
        if (index < TriggerPulls.Length)
        {
            TriggerPulls[CurrentTriggerPull].Release();
            CurrentTriggerPull = index;
        }
    }

    public void Press()
    {
        TriggerPulls[CurrentTriggerPull].Press();
    }

    public void Release()
    {
        TriggerPulls[CurrentTriggerPull].Release();
    }

    private void Update()
    {
        Aim.SetShootPositionAndDirection(ShootSource.transform.position, ShootSource.transform.forward);
        if (Input.GetButtonDown("Fire1"))
        {
            Press();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Release();
        }
        if (Input.GetButtonUp("Submit"))
        {
            Magazine.Reload();
        }
    }
}

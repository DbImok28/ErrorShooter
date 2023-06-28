using ECM.Controllers;
using System.Linq;
using UnityEngine;

public class PlayerController : BaseFirstPersonController, ISaveable
{
    [Header("Inventory")]
    [SerializeField] public PlayerInventory Inventory;
    [Header("Weapon")]
    [SerializeField] public GameObject WeaponSocket;

    private GameObject ActiveWeaponGameObject;
    private Weapon ActiveWeapon;
    public int ActiveWeaponIndex = -1;
    private bool WeaponInHand = false;

    private PlayerEnvironmentInteraction environmentInteraction;

    public void StartSwapWeapon()
    {
        WeaponInHand = false;
    }
    public bool AssignWeaponToSocket(GameObject weaponGameObject)
    {
        var newWeapon = weaponGameObject.GetComponentInChildren<Weapon>();
        if (newWeapon != null)
        {
            ActiveWeaponGameObject = weaponGameObject;
            ActiveWeapon = newWeapon;
            return true;
        }
        return false;
    }
    public bool AssignWeaponToSocket(int index)
    {
        if (index >= 0 && index < Inventory.Weapons.Count)
        {
            ActiveWeaponIndex = index;
            var weaponGameObject = Instantiate(Inventory.Weapons[index], WeaponSocket.transform);
            if (!AssignWeaponToSocket(weaponGameObject))
            {
                Destroy(weaponGameObject);
                return false;
            }
            return true;
        }
        return false;
    }
    public void DestroyWeaponFromSocket()
    {
        if (ActiveWeaponGameObject != null)
        {
            Destroy(ActiveWeaponGameObject);
            ActiveWeaponGameObject = null;
            ActiveWeapon = null;
        }
    }
    public void EndSwapWeapon()
    {
        if (ActiveWeapon != null)
        {
            WeaponInHand = true;
        }
    }

    public void SwapWeapon(int index)
    {
        if (index >= 0 && index < Inventory.Weapons.Count)
        {
            StartSwapWeapon();
            // Hide weapon anim
            DestroyWeaponFromSocket();

            if (AssignWeaponToSocket(index))
            {
                // Show weapon Anim
                EndSwapWeapon();
            }
        }
    }
    public void SwapToNextWeapon()
    {
        SwapWeapon((ActiveWeaponIndex + 1) % Inventory.Weapons.Count);
    }

    protected override void HandleInput()
    {
        // Toggle pause / resume.
        // By default, will restore character's velocity on resume (eg: restoreVelocityOnResume = true)

        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
        }
            

        // Player input

        moveDirection = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0.0f,
            z = Input.GetAxisRaw("Vertical")
        };

        run = Input.GetButton("Fire3");

        jump = Input.GetButton("Jump");

        crouch = Input.GetKey(KeyCode.C);

        if (WeaponInHand)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                ActiveWeapon.Press();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                ActiveWeapon.Release();
            }
            if (Input.GetButtonUp("Submit"))
            {
                ActiveWeapon.Magazine.Reload();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                SwapToNextWeapon();
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            environmentInteraction.DisplayOrHideNote();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            environmentInteraction.PickUpKey();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            environmentInteraction.AttachKey();
        }
        environmentInteraction.Interact();

    }

    public void Start()
    {
        if (Inventory == null)
        {
            Inventory = GetComponent<PlayerInventory>();
        }
        SwapWeapon(0);

        environmentInteraction= GetComponent<PlayerEnvironmentInteraction>();
        environmentInteraction.Init(Inventory);

    }

    public void SaveData(ref GameData gameData)
    {
        gameData.playerX=transform.position.x;
        gameData.playerY = transform.position.y;
        gameData.playerZ = transform.position.z;
    }

    public void LoadData(GameData gameData)
    {
        transform.position=new Vector3(gameData.playerX, gameData.playerY, gameData.playerZ);
    }
}

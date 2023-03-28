using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Parameters")]
    public GameObject ShootSource;
    public float Damage = 1;
    public float FireRate = 120;
    public float MaxShootDistance = 4000;

    [Header("SFX")]
    public AudioSource ShootAudioSource;
    public AudioClip ShootClip;

    [Header("Events")]
    public UnityEvent ShootEvent;
    public UnityEvent<RaycastHit> ShootHitEvent;

    private bool IsFireRateDelayNow = false;

    #region Mono
    private void Start()
    {
        if (!ShootSource)
        {
            ShootSource = gameObject;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }
    #endregion

    public void Shoot()
    {
        if (!IsFireRateDelayNow)
        {
            IsFireRateDelayNow = true;
            var hit = RaycastShoot();
            ShootEvent.Invoke();
            if (hit != null)
            {
                ShootHitEvent.Invoke(hit.Value);
                if (ShootAudioSource && ShootClip)
                {
                    ShootAudioSource.PlayOneShot(ShootClip);
                }
                // Test code
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                Destroy(sphere.GetComponent<Collider>());
                Destroy(Instantiate(sphere, hit.Value.point, Quaternion.identity), 5);
            }
            StartCoroutine(FireRateDelay());
        }
    }

    private IEnumerator FireRateDelay()
    {
        yield return new WaitForSeconds(60.0f / FireRate);
        IsFireRateDelayNow = false;
    }

    private RaycastHit? RaycastShoot()
    {
        if (Physics.Raycast(ShootSource.transform.position, ShootSource.transform.forward, out RaycastHit hit, MaxShootDistance))
        {
            return hit;
        }
        return null;
    }

    #region Debug
    void OnDrawGizmos()
    {
        if (!ShootSource)
        {
            ShootSource = gameObject;
        }

        var hit = RaycastShoot();
        if (RaycastShoot() != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.Value.point, 0.2f);
            Gizmos.DrawLine(ShootSource.transform.position, hit.Value.point);
        }
    }
    #endregion
}

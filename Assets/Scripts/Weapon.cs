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
    public UnityEvent OnShoot;
    public UnityEvent<RaycastHit> OnShootHit;

    private bool IsFireRateDelayNow = false;
    private GameObject ShootPointSphere;

    #region Mono
    private void Start()
    {
        if (!ShootSource)
        {
            ShootSource = gameObject;
        }
        // Debug only
        ShootPointSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Destroy(ShootPointSphere.GetComponent<Collider>());
        ShootPointSphere.GetComponent<MeshRenderer>().material.color = Color.green;
        ShootPointSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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
            OnShoot.Invoke();
            if (hit != null)
            {
                OnShootHit.Invoke(hit.Value);
                if (ShootAudioSource && ShootClip)
                {
                    ShootAudioSource.PlayOneShot(ShootClip);
                }

                var health = hit.Value.collider.gameObject.GetComponent<HealthComponent>();
                if (health)
                {
                    health.TakeDamage(Damage);
                }
                // Test code
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Destroy(sphere.GetComponent<Collider>());
                sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                sphere.transform.localPosition = hit.Value.point;
                sphere.transform.localRotation = Quaternion.identity;

                Destroy(sphere, 5);
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
            // Debug only
            if (ShootPointSphere) ShootPointSphere.transform.localPosition = hit.point;
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

using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public class RaycastWeaponAttack : WeaponAttack
    {
        [SerializeField] private float Damage = 1;
        [SerializeField] private float MaxShootDistance = 4000;

        [SerializeField] private GameObject DebugShootSource;
        private GameObject DebugShootPointSphere;
        [SerializeField] private bool ShowDebugSphere = true;

        private void Start()
        {
            // Debug code
            if (ShowDebugSphere && DebugShootSource != null)
            {
                DebugShootPointSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Destroy(DebugShootPointSphere.GetComponent<Collider>());
                DebugShootPointSphere.GetComponent<MeshRenderer>().material.color = Color.green;
                DebugShootPointSphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            }
        }

        private void Update()
        {
            if (DebugShootSource != null && DebugShootPointSphere)
            {
                if (Physics.Raycast(DebugShootSource.transform.position, DebugShootSource.transform.forward, out RaycastHit hit, MaxShootDistance))
                {
                    DebugShootPointSphere.transform.localPosition = hit.point;
                }
            }
        }

        public override bool Attack(Vector3 position, Vector3 direction)
        {
            //print(position);
            if (Physics.Raycast(position, direction, out RaycastHit hit, MaxShootDistance))
            {
                var health = hit.collider.gameObject.GetComponent<HealthComponent>();
                if (health)
                {
                    health.TakeDamage(Damage);
                }

                // Debug code
                if (ShowDebugSphere)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    Destroy(sphere.GetComponent<Collider>());
                    sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                    sphere.transform.localPosition = hit.point;
                    sphere.transform.localRotation = Quaternion.identity;
                    Destroy(sphere, 5);
                }
                return true;
            }
            return false;
        }
    }
}

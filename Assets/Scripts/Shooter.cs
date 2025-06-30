using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed = 10f;
    public float ProjectileLifetime = 1f;
    public float ShootingDelay = 0.1f;
    public bool IsShooting = false;
    public bool IsEnemy = false;

    private Coroutine shootingCoroutine;
    void Start()
    {
        if (IsEnemy)
        {
            IsShooting = true;
        }
    }

    void Update()
    {
        if (IsShooting && shootingCoroutine == null)
        {
            shootingCoroutine = StartCoroutine(shootContinuesly());
        }
        else if (!IsShooting && shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }

    }

    IEnumerator shootContinuesly()
    {
        while (true)
        {
            var p = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Destroy(p, ProjectileLifetime);
            var rb = p.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                //rb.AddForce(transform.up * ProjectileSpeed, ForceMode2D.Impulse);
                rb.linearVelocity = transform.up * ProjectileSpeed;
            }
            yield return new WaitForSeconds(ShootingDelay);
        }
    }
}

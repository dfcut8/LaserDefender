using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [Header("Projectile")]
    public GameObject ProjectilePrefab;
    public float ProjectileSpeed = 10f;
    public float ProjectileLifetime = 1f;

    [Header("Shooting")]
    public float ShootingDelay = 0.1f;
    public float ShootingSpread = 0f;
    public float MinShootingDelay = 0.1f;

    [Header("Enemy")]
    public bool IsEnemy = false;

    [HideInInspector] public bool IsShooting = false;

    public UnityEvent OnShoot;

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
            Debug.Log($"{Time.fixedTimeAsDouble}: Shooting projectile");
            OnShoot?.Invoke();
            var p = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            Destroy(p, ProjectileLifetime);
            var rb = p.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.up * ProjectileSpeed;
            }
            yield return new WaitForSeconds(ShootingDelay + getRandomShootingSpread());
        }
    }

    private float getRandomShootingSpread()
    {
        if (ShootingSpread <= 0f)
        {
            return 0f;
        }
        var spread = Math.Max(UnityEngine.Random.Range(-ShootingSpread, ShootingSpread), MinShootingDelay);
        return spread;
    }
}

using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int HP = 100;
    public ParticleSystem HitFx;
    public bool ShakeCameraOnHit = false;
    private CameraShake cameraShake;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        if (cameraShake == null && ShakeCameraOnHit)
        {
            Debug.LogError("CameraShake component not found on main camera. Camera shake will not occur on hit.");
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<DamageDealer>(out var damageDealer))
        {
            takeDamage(damageDealer.Damage);
            playHitFx();
            shakeCamera();
            Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}, took {damageDealer.Damage} damage.");
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Player collided with: " + collision.name);
        }
    }

    private void shakeCamera()
    {
        if (ShakeCameraOnHit && cameraShake != null)
        {
            cameraShake.ShakeCamera();
        }
    }

    void takeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Debug.Log($"{gameObject.name} has died.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Player HP: " + HP);
        }
    }

    private void playHitFx()
    {
        if (HitFx != null)
        {

            ParticleSystem hitFxInstance = Instantiate(HitFx, transform.position, Quaternion.identity);
            //HitFx.Play();
            Destroy(hitFxInstance.gameObject, hitFxInstance.main.duration + hitFxInstance.main.startLifetime.constantMax);
        }
        else
        {
            Debug.LogWarning("HitFx ParticleSystem is not assigned.");
        }
    }
}

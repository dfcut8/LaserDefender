using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int HP = 100;
    public ParticleSystem HitFx;

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
            Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}, took {damageDealer.Damage} damage.");
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Player collided with: " + collision.name);
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
            HitFx.Play();
            Destroy(hitFxInstance.gameObject, hitFxInstance.main.duration + hitFxInstance.main.startLifetime.constantMax);
        }
        else
        {
            Debug.LogWarning("HitFx ParticleSystem is not assigned.");
        }
    }
}

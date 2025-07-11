using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Background Music")]
    public AudioClip backgroundMusicClip;
    [Range(0.0f, 1.0f)] public float backgroundMusicVolume = 0.5f;

    [Header("Shooting")]
    public AudioClip shootingClip;
    [Range(0.0f, 1.0f)] public float shootingVolume = 0.5f;

    [Header("Explosions")]
    public AudioClip EnemyExplosion1;
    [Range(0.0f, 1.0f)] public float EnemyExplosion1Volume = 0.5f;

    public EnemySpawner enemySpawner;

    private void Awake()
    {
        if (backgroundMusicClip != null)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = backgroundMusicClip;
            audioSource.loop = true;
            audioSource.volume = backgroundMusicVolume;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music clip is not assigned in AudioManager.");
        }
    }

    void OnEnable()
    {
        if (enemySpawner != null)
        {
            enemySpawner.OnEnemySpawn.AddListener(HandleEnemySpawned);
        }
    }

    private void HandleEnemySpawned(GameObject enemy)
    {
        if (enemy.TryGetComponent<HealthManager>(out var healthManager))
        {
            healthManager.OnHit.AddListener(PlayEnemyExplosion1);
        }
        else
        {
            Debug.LogWarning("Enemy spawned does not have a HealthManager component.");
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void PlayShootingClip()
    {
        if (shootingClip != null)
        {
            Debug.Log("Playing shooting sound");
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
        else
        {
            Debug.LogWarning("Shooting clip is not assigned in AudioManager.");
        }
    }

    public void PlayEnemyExplosion1()
    {
        if (EnemyExplosion1 != null)
        {
            Debug.Log("Playing explosion1 sound");
            AudioSource.PlayClipAtPoint(EnemyExplosion1, Camera.main.transform.position, EnemyExplosion1Volume);
        }
        else
        {
            Debug.LogWarning("Enemy explosion clip is not assigned in AudioManager.");
        }
    }
}

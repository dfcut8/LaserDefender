using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Background Music")]
    public AudioClip backgroundMusicClip;
    [Range(0.0f, 1.0f)] public float backgroundMusicVolume = 0.5f;

    [Header("Shooting")]
    public AudioClip shootingClip;
    [Range(0.0f, 1.0f)] public float shootingVolume = 0.5f;

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
            Debug.Log($"{Time.fixedTimeAsDouble}: Playing Sound");
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
        else
        {
            Debug.LogWarning("Shooting clip is not assigned in AudioManager.");
        }
    }
}

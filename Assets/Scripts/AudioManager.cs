using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Background Music")]
    public AudioClip backgroundMusicClip;
    [Range(0.0f, 1.0f)] public float backgroundMusicVolume = 0.5f;

    [Header("Shooting")]
    public AudioClip shootingClip;
    [Range(0.0f, 1.0f)] public float shootingVolume = 0.5f;

    void Start()
    {

    }

    void Update()
    {

    }
}

using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public float Speed = 0.1f;
    private Renderer r;

    public void Awake()
    {
        r = GetComponent<Renderer>();
    }
    void Start()
    {

    }

    void Update()
    {
        r.material.mainTextureOffset = new Vector2(0, Time.time * Speed);
    }
}

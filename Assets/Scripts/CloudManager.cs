using UnityEngine;

public class CloudManager : MonoBehaviour
{
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
        r.material.mainTextureOffset = new Vector2(0, Time.time * 0.1f);
    }
}

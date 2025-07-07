using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float Speed = 1f;
    void Start()
    {

    }

    void Update()
    {
        transform.position += new Vector3(0, Vector3.up.y * Speed * Time.deltaTime, 0);
    }
}

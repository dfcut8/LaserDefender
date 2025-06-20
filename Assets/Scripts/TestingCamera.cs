using UnityEngine;

public class TestingCamera : MonoBehaviour
{
    void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}

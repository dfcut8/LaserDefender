using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float speed = 1f;
    Vector2 moveInput;
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = moveInput * Time.deltaTime * speed;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("Move Input: " + moveInput);
    }
}

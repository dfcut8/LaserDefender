using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float speed = 1f;
    public float paddingLeft = 0.1f;
    public float paddingRight = 0.1f;
    public float paddingTop = 0.1f;
    public float paddingBottom = 0.1f;
    Vector2 moveInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Start()
    {
        InitBounds();
        Debug.Log("PlayerManager started with speed: " + speed);
    }
    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector3 delta = moveInput * Time.deltaTime * speed;
        Vector2 newPosition = new();
        newPosition.x = Mathf.Clamp(
            transform.position.x + delta.x,
            minBounds.x + paddingLeft,
            maxBounds.x - paddingRight
        );
        newPosition.y = Mathf.Clamp(
            transform.position.y + delta.y,
            minBounds.y + paddingBottom,
            maxBounds.y - paddingTop
        );
        transform.position = newPosition;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("Move Input: " + moveInput);
    }
}

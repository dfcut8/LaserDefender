using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public float speed = 1f;
    public float constantSpeed = 1f;
    public float paddingLeft = 0.1f;
    public float paddingRight = 0.1f;
    public float paddingTop = 0.1f;
    public float paddingBottom = 0.1f;
    Vector2 moveInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    private Shooter shooter;
    private Camera cam;

    public void Awake()
    {
        cam = Camera.main;
        shooter = GetComponent<Shooter>();
        if (shooter == null)
        {
            Debug.LogError("Shooter component not found on PlayerManager.");
        }
        else
        {
            Debug.Log("Shooter component found: " + shooter.name);
        }
    }

    public void Start()
    {
        //InitBounds();
        Debug.Log("PlayerManager started with speed: " + speed);
    }
    public void Update()
    {
        Move();
    }

    void InitBounds()
    {

        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        InitBounds();
        //transform.position = new Vector3(
        //    transform.position.x + moveInput.x * speed * Time.deltaTime,
        //    transform.position.y + moveInput.y * speed * Time.deltaTime,
        //    transform.position.z
        //);

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
        transform.position = newPosition + new Vector2(0, Vector2.up.y * constantSpeed * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log("Move input received: " + moveInput);
    }

    public void OnAttack(InputValue value)
    {
        //Debug.Log("Fire button pressed with value: " + value.isPressed);
        if (value.isPressed)
        {
            Debug.Log("Fire button pressed.");
            shooter.IsShooting = true;
        }
        else
        {
            shooter.IsShooting = false;
        }
    }
}

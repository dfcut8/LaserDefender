using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    private InputSystem inputActions;
    void Awake()
    {
        inputActions = new InputSystem();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.GameReset.performed += OnGameReset;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.GameReset.Disable();
    }

    private void OnGameReset(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Handle game reset logic here
        Debug.Log("Game Reset Triggered");
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

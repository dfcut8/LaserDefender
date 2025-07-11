using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public bool AllowGameReset = true;
    private InputSystem inputActions;
    void Awake()
    {
        inputActions = new InputSystem();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.GameReset.performed += ResetLevel;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.GameReset.Disable();
    }

    private void ResetLevel(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        // Handle game reset logic here
        Debug.Log("Game Reset Triggered");
        if (!AllowGameReset)
        {
            Debug.LogWarning("Game reset is not allowed.");
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void StartLevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

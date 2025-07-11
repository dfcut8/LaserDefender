using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int CurrentScore = 0;

    //public UnityEvent OnScoreChanged;

    void Awake()
    {
        CurrentScore = 0;
        Debug.Log("ScoreManager initialized. Current Score: " + CurrentScore);
    }

    void Start()
    {
        CurrentScore = 0;
        Debug.Log("ScoreManager initialized. Current Score: " + CurrentScore);
    }

    void Update()
    {

    }

    public void AddScore(int score)
    {
        //OnScoreChanged?.Invoke();
        CurrentScore += score;
        Debug.Log($"Score added: {score}. Current Score: {CurrentScore}");
    }

    public void ResetScore()
    {
        //OnScoreChanged?.Invoke();
        CurrentScore = 0;
        Debug.Log("Score reset to zero.");
    }
}

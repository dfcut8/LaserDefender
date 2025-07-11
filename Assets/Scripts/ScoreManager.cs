using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public int ScoresOnEnemyHit = 100;

    public int CurrentScore { get; private set; } = 0;

    //public UnityEvent OnScoreChanged;  

    void Awake()
    {
        CurrentScore = 0;
        Debug.Log("ScoreManager initialized. Current Score: " + CurrentScore);
    }

    void OnEnable()
    {
        if (enemySpawner != null)
        {
            enemySpawner.OnEnemySpawn.AddListener(HandleEnemySpawned);
        }
    }

    private void HandleEnemySpawned(GameObject enemy)
    {
        enemy.GetComponent<HealthManager>().OnHit.AddListener(() => AddScore(ScoresOnEnemyHit));
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
        CurrentScore += score;
        Debug.Log($"Score added: {score}. Current Score: {CurrentScore}");
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        Debug.Log("Score reset to zero.");
    }
}

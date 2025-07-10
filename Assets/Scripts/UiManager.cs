using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    private int currentScore;
    private TextMeshProUGUI text;

    void Awake()
    {
        //scoreManager.OnScoreChanged.AddListener(UpdateScoreText);
        text = GetComponentInChildren<TextMeshProUGUI>();
        //UpdateScoreText();
    }
    public void Update()
    {
        text.text = scoreManager.CurrentScore.ToString();
    }
}

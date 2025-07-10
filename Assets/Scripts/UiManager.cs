using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameObject player;
    private TextMeshProUGUI text;
    private Slider slider;

    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        slider.maxValue = player.GetComponent<HealthManager>().HPMax;
    }

    public void Update()
    {
        slider.value = player.GetComponent<HealthManager>().HPCurrent;
        text.text = scoreManager.CurrentScore.ToString();
    }
}

using UnityEngine;
using TMPro;
public class Scormanager : MonoBehaviour
{
    public static Scormanager instance;
    private int score;
    public TextMeshProUGUI ScorText;
    public TextMeshProUGUI HiScorText;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
         UpdateUI();
    }
    public void AddScore(int points)
    {
        score += points;
        HiScorManager.Instance.UpdateScore(score);
        UpdateUI();
    }
    void UpdateUI()
    {
        ScorText.text = "Score: " + score;
        HiScorText.text = "Highscore: " + HiScorManager.Instance.GetHighScore();
    }
}

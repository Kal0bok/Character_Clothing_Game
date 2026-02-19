using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
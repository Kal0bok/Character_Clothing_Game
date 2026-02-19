using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int lives = 3; 
    public TextMeshProUGUI livesText;

    void Start()
    {
        UpdateUI();
    }

    public void TakeDamage()
    {
        lives--;
        UpdateUI();

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void UpdateUI()
    {
        livesText.text = "Lives: " + lives;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
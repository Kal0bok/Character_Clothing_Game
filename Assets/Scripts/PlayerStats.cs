using UnityEngine;
using TMPro; // Добавляем поддержку TextMeshPro

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int score = 0;

    // Теперь здесь TMP_Text вместо обычного Text
    public TMP_Text hpText;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Игра окончена!");
        }
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (hpText != null) hpText.text = "HP: " + health;
        if (scoreText != null) scoreText.text = "Score: " + score;
    }
}
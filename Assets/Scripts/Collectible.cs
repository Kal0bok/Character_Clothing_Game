using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value = 10; // Для разных пончиков поставь разное число в инспекторе

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().AddScore(value);
            Destroy(gameObject); // Предмет исчезает
        }
    }
}
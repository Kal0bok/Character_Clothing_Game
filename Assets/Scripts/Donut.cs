using UnityEngine;

public class Donut : MonoBehaviour
{
    public int points = 1;
    public AudioClip collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource playerAudio = other.GetComponent<AudioSource>();
            
            if (playerAudio != null && collectSound != null)
            {
                playerAudio.PlayOneShot(collectSound);
            }

            ScoreManager.instance.AddScore(points);

            Destroy(gameObject);
        }
    }
}
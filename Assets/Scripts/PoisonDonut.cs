using UnityEngine;

public class PoisonDonut : MonoBehaviour
{
    public AudioClip poisonSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource playerAudio = other.GetComponent<AudioSource>();
            
            if (playerAudio != null && poisonSound != null)
            {
                playerAudio.PlayOneShot(poisonSound);
            }

            HealthManager hm = FindObjectOfType<HealthManager>();
            if (hm != null)
            {
                hm.TakeDamage();
            }

            Destroy(gameObject); 
        }
    }
}
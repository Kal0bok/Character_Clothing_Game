using UnityEngine; 
using System.Collections;


using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 20;
    public bool destroyOnTouch = false; // Для шаров - true, для лавы - false

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().TakeDamage(damage);

            if (destroyOnTouch)
                Destroy(gameObject);
        }
    }
}
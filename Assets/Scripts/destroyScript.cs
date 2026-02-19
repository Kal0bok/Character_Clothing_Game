using TMPro;
using UnityEngine;

public class destroyScript : MonoBehaviour
{
    SoundEffectScript sfx;
    public TMP_Text counterText;
    private int destroyedDonuts = 0;

    void Start()
    {
        sfx = FindFirstObjectByType<SoundEffectScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("donut"))
        {
            Destroy(collision.gameObject);
            destroyedDonuts++;
            sfx.PlaySFX(0);
            counterText.text = "Donut Destroyed:\n" + destroyedDonuts;
        }
    }
}

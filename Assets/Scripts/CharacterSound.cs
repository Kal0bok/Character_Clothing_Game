using UnityEngine;
using UnityEngine.EventSystems; // Obligāti nepieciešams, lai strādātu ar peles notikumiem

public class CharacterSound : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource audioSource;

    void Start()
    {
        // Iegūst atsauci uz AudioSource komponenti, kas pievienota šim objektam
        audioSource = GetComponent<AudioSource>();
    }

    // Šī metode tiek izsaukta automātiski, kad peles kursors uziet uz objekta
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Pārbaudām, vai audio komponente eksistē un vai skaņa jau netiek atskaņota
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
            // Izvadām ziņojumu konsolē par skaņas atskaņošanu konkrētam tēlam
            Debug.Log("Atskaņo skaņu tēlam: " + gameObject.name);
        }
    }
}
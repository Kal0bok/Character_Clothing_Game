using UnityEngine;

public class SoundEffectScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    public void PlaySFX (int ix)
    {
        audioSource.PlayOneShot(audioClips[ix]);
    }
}

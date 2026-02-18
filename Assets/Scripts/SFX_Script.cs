using UnityEngine;

public class SFX_Script : MonoBehaviour
{
   public AudioSource sfxSource;
   public AudioClip[] audioClips;

    public void PlaySFX (int ix)
    {
        if(sfxSource.isPlaying) 
            sfxSource.Stop();

        sfxSource.PlayOneShot(audioClips[ix]);
    }
}

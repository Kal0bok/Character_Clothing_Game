using UnityEngine;
using UnityEngine.Audio; // Obligāti nepieciešams, lai strādātu ar Audio Mixer
using UnityEngine.UI; // Obligāti nepieciešams, lai strādātu ar Slider (slīdni)

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer; // Šeit jāpievieno savs MainMixer caur Unity inspektoru
    public Slider slider; // Šeit jāpievieno savs Slider objekts caur Unity inspektoru

    void Start()
    {
        // Iestatām slīdņa vērtības: skaļums mikserī parasti ir no -80 līdz 20 decibeliem
        slider.minValue = -40f;
        slider.maxValue = 0f;
        slider.value = 0f; // Sākumā iestatām maksimālo skaļumu

        // Pievienojam klausītāju, kas reaģēs uz slīdņa vērtības maiņu
        slider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float sliderValue)
    {
        // Ja slīdnis ir pašā apakšā, pilnībā izslēdzam skaņu
        if (sliderValue <= -39f) sliderValue = -80f;

        // Iestatām vērtību mikserī, izmantojot Exposed parametra nosaukumu
        mixer.SetFloat("MyExposedVolume", sliderValue);
    }
}
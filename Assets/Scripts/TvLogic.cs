using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TvLogic : MonoBehaviour
{
    [Header("suply power")]
    public Toggle electricToggle; 
    private bool isTvOn = false;

    [Header("display objects")]
    public GameObject TV_display;
    public GameObject channelsParent;

    [Header("Dropdown")]
    public TMP_Dropdown channelDropdown;
    public GameObject channel1; 
    public GameObject channel2;

    [Header("slider")]
    public Slider volumeSlider;


    void Start()
    {
        if (volumeSlider != null)
        {
            AudioListener.volume = volumeSlider.value;
        }

        ApplyTvState();
    }

    public void ChangeVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void ChangeChannel(int index)
    {
        if (channel1 != null) channel1.SetActive(index == 0);
        if (channel2 != null) channel2.SetActive(index == 1);
    }

    public void ClickPowerButton()
    {
        if (electricToggle != null && electricToggle.isOn)
        {
            isTvOn = !isTvOn;
        }
        else
        {
            isTvOn = false;
        }
        ApplyTvState();
    }

    public void OnElectricToggleChanged(bool hasPower)
    {
        if (!hasPower)
        {
            isTvOn = false;
        }
        ApplyTvState();
    }

    private void ApplyTvState()
    {
        bool works = isTvOn && (electricToggle != null && electricToggle.isOn);

        if (works)
        {
            if (channelsParent != null) channelsParent.SetActive(true);
            if (TV_display != null) TV_display.SetActive(false);
            
            if (channelDropdown != null) ChangeChannel(channelDropdown.value);
        }
        else
        {
            if (channelsParent != null) channelsParent.SetActive(false);
            if (TV_display != null) TV_display.SetActive(true);
        }
    }
}
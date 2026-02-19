using UnityEngine;

public class TVManager : MonoBehaviour
{
    [Header("Kanālu iestatījumi")]
    public GameObject[] channels; // Šeit inspector logā ievelc Kanal1, Kanal2, Kanal3
    public GameObject offScreen;  // Objekts Multi_4 (melnais ekrāns)

    private int currentChannel = 0;
    private bool isOn;

    void Awake()
    {
        // Startējot pārbaudām: ja melnais ekrāns ir ieslēgts, tātad TV pašlaik ir IZSLĒGTS
        if (offScreen != null)
        {
            isOn = !offScreen.activeSelf;
        }
        else
        {
            isOn = true; // Gadījumam, ja offScreen nav pievienots inspector logā
        }
    }

    void Start()
    {
        UpdateTVVisuals();
    }

    // Pievieno šo metodi pogai OFF
    public void TogglePower()
    {
        isOn = !isOn;
        Debug.Log(isOn ? "TV ieslēgts" : "TV izslēgts");
        UpdateTVVisuals();
    }

    // Pievieno šo metodi pogai Up
    public void NextChannel()
    {
        if (!isOn) return; // Ja izslēgts, poga nedarbojas

        currentChannel++;
        if (currentChannel >= channels.Length) currentChannel = 0;

        Debug.Log("Pārslēgts uz kanālu: " + currentChannel);
        UpdateTVVisuals();
    }

    // Pievieno šo metodi pogai Down
    public void PreviousChannel()
    {
        if (!isOn) return; // Ja izslēgts, poga nedarbojas

        currentChannel--;
        if (currentChannel < 0) currentChannel = channels.Length - 1;

        Debug.Log("Pārslēgts uz kanālu: " + currentChannel);
        UpdateTVVisuals();
    }

    private void UpdateTVVisuals()
    {
        // Rādām melno ekrānu tikai tad, kad TV ir izslēgts
        if (offScreen != null)
        {
            offScreen.SetActive(!isOn);
        }

        // Pārlasām kanālus
        for (int i = 0; i < channels.Length; i++)
        {
            if (channels[i] != null)
            {
                // Kanāls ieslēdzas tikai tad, ja TV ir IESLĒGTS un indekss sakrīt
                channels[i].SetActive(isOn && i == currentChannel);
            }
        }
    }
}
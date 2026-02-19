using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class Button : MonoBehaviour
{
    // You can call this function from the Button component in the Inspector
    public void OnButtonClick()
    {
        Debug.Log("Button was clicked! Action performed.");

        // Example action: Change the background color to a random color
        Application.Quit();
    }

    // Example of a function that takes a parameter
    public void PrintMessage(string message)
    {
        Debug.Log("Button says: " + message);
    }
}
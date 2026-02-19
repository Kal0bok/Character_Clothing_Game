using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class NameScript : MonoBehaviour
{
    private string text;
    private string[] input = { "Sveiks", "Jauku dienu", "Prieks Tevi redzēt", "Uzredzēšanos",
        "Jauki, ka atnāci", "Tiksimies rīt"};
    private int rand;
    public GameObject inputField;
    public GameObject textField;
    public GameObject reverseTextToggle;

    public void GetText()
    {
        rand = Random.Range(0, input.Length);
        text = inputField.GetComponent<TMP_InputField>().text;
        textField.GetComponent<TMP_Text>().text = input[rand] + ", " + text + "!";

        reverseTextToggle.GetComponent<Toggle>().interactable = true;
        if (reverseTextToggle.GetComponent<Toggle>().isOn)
        {
            ReverseText();
        }
    }

    public void ReverseText()
    {
        char[] charArray = textField.GetComponent<TMP_Text>().text.ToCharArray();
        System.Array.Reverse(charArray);
        textField.GetComponent<TMP_Text>().text = new string(charArray);

    }
}

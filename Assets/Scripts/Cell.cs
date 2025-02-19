using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public TMP_Text UIField;

    public char GetLetter()     //Get the character of the cell
    {
        return UIField.text[0];
    }

    public void PushColour(Color newColor)  //Change the colour of the cell block
    {
        //UIField.color = newColor;

        GetComponent<Image>().color = newColor;
    }
}

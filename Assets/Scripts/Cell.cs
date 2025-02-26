using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public TMP_InputField UIField;

    private void Awake()
    {
        UIField = GetComponent<TMP_InputField>();
    }

    public char GetLetter()     //Get the character of the cell
    {
        return UIField.text.Length > 0 ? UIField.text[0] : '-';     //Return a '-' if the field is EMPTY
    }

    public void PushColour(Color newColor)  //Change the colour of the cell block
    {
        //UIField.color = newColor;

        GetComponent<Image>().color = newColor;
    }

    //Toggle interactable state (triggered by the Game's activeIndexProperty via the Row)
    public void SetState(bool state)
    {
        UIField.interactable = state;
    }

    public void ValidateCell()  //RETURN statement ensure recursive behaviour is stopped before toggling final action (triggered by the TMP_InputField's Unity Event)
    {
        if (UIField.text.Length <= 0)   //Check if the cell is empty
        {
            return;
        }

        if (UIField.text.Length > 1)    //Check if the cell has more than 1 character
        {
            UIField.text = UIField.text[0].ToString();
            return;
        }

        if (!char.IsLetter(UIField.text[0]))    //Check if the cell has an alphabetical character
        {
            UIField.text = "";
            return;
        }

        if (char.IsLower(UIField.text[0]))  //Check if the cell is capitalised
        {
            UIField.text = UIField.text.ToUpper();
            return;
        }

        UINavigation.GetNext(); //Once valid character entered move to the next cell
    }
}

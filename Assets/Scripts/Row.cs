using UnityEngine;

public class Row : MonoBehaviour
{
    public Cell[] cells;    //Get all of the cells in a list

    private void Awake()
    {
        cells = GetComponentsInChildren<Cell>();
    }

    public string GetWord()     //Combine all the letters into a word
    {
        string word = "";

        foreach (Cell cell in cells)
        {
            word += cell.GetLetter();
        }

        return word;
    }

    public void PushColour(int index, Color newColor, Cell.colourStates newState)   //Receive a colour and push it into one of the cells
    {
        cells[index].PushColour(newColor, newState);
    }

    //Turn the row and all of its cells on/off (triggered by the Game's activeIndexProperty)
    public void SetState(bool state)
    {
        foreach (Cell cell in cells)
        {
            cell.SetState(state);
        }
    }
}

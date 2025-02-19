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

    public void PushColour(int index, Color newColor)   //Receive a colour and push it into one of the cells
    {
        cells[index].PushColour(newColor);
    }
}

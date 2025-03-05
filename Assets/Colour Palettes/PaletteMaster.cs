using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaletteMaster : MonoBehaviour
{
    //Elements to change when the colour changes
    public Image panel;
    public Game game;

    [SerializeField]
    private ColourPalette currentPalette;   //Property with (BIG) setter to push new colours based on the newly selected palette

    public ColourPalette currentPaletteProperty
    {
        get
        {
            return currentPalette;
        }

        set
        {
            currentPalette = value;
            Camera.main.backgroundColor = currentPalette.backgroundColour;

            panel.color = currentPalette.panelColour;

            game.hot = currentPalette.hot;
            game.warm = currentPalette.warm;
            game.cold = currentPalette.cold;

            foreach (Row row in game.rows)  //Check and set the colour of every row in the game
            {
                row.GetComponent<Image>().color = currentPalette.rowColour;
                foreach (Cell cell in row.cells)    //Check and set the colour of every cell in the row / Use the cell's enum to figure out which colour I need to be
                {
                    //cell.GetComponent<Image>().color = currentPalette.cellColour;
                    cell.GetComponentInChildren<TMP_Text>().color = currentPalette.regularTextColour;   //?
                    Image cellField = cell.GetComponent<Image>();
                    if (cell.myState == Cell.colourStates.Regular)
                    {
                        cellField.color = currentPalette.cellColour;
                    }

                    if (cell.myState == Cell.colourStates.Hot)
                    {
                        cellField.color = currentPalette.hot;
                    }

                    if (cell.myState == Cell.colourStates.Warm)
                    {
                        cellField.color = currentPalette.warm;
                    }

                    if (cell.myState == Cell.colourStates.Cold)
                    {
                        cellField.color = currentPalette.cold;
                    }
                }
            }
        }
    }
}

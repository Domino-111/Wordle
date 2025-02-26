using UnityEngine;

public class Game : MonoBehaviour
{
    public string word = "HAPPY";   //The correct answer

    public Row activeRow;   //Row of the interface we're guessing

    public Row[] rows;  //List of all the rows, expand if you want more
    public int activeIndex;     // Active index and its property will change the activeRow if itself is changed
    public int activeIndexProperty
    {
        get
        {
            return activeIndex;
        }

        set
        {
            activeIndex = Mathf.Clamp(value, 0, rows.Length - 1);
            activeRow = rows[activeIndex];
            foreach (Row row in rows)
            {
                row.SetState(false);
            }
            activeRow.SetState(true);
        }
    }

    public Color hot, warm, cold;   //Colour palette

    public bool gameRunning = true;     //Stop the game from running if win/lose conditions are triggered

    void Start()
    {
        //GuessWord();

        activeIndexProperty = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   //Submit a guess when I press ENTER (Return)
        {
            GuessWord();
        }

        //Move forward & back on the activeRow if I press (SHIFT) TAB
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                UINavigation.GetPrevious();
            }

            else
            {
                UINavigation.GetNext();
            }
        }

        //Move back (in addition to deleting content) if I press BACKSPACE
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            UINavigation.GetPrevious();
        }
    }

    //Retrieve the letters of the currently active row
    public void GuessWord()
    {
        if (!gameRunning)
        {
            return;
        }

        string guess = activeRow.GetWord();

        if (guess.Contains('-'))    //Catch the function if we guess a word that contains a '-' (aka not 5 letters)
        {
            UINavigation.SelectCell(activeRow.cells[0]);
            return;
        }

        print($"Comparing the word {word} with the word {guess}");

        for (int i = 0; i < 5; i++)
        {
            print($"Comparing {word[i]} against {guess[i]}");

            if (word[i] == guess[i])    //Run when letter is correct and in correct spot
            {
                //print("<color=green>They match!</color>");
                activeRow.PushColour(i, hot);
            }

            else if (word.Contains(guess[i]))   //Run when letter is in the word but wrong spot
            {
                //print($"<color=yellow> The word contains the letter {guess[i]} </color>");
                activeRow.PushColour(i, warm);
            }

            else    //Run when letter doesn't exist in word
            {
                //print($"<color=red> The word does not contain the letter {guess[i]} </color>");
                activeRow.PushColour(i, cold);
            }
        }

        if (guess == word)  //Win condition
        {
            print("You Win!");
            gameRunning = false;

            foreach (Cell cell in activeRow.cells)
            {
                cell.UIField.readOnly = true;
            }

            return;
        }

        if (activeIndexProperty >= rows.Length - 1)     //Lose condition
        {
            print("You Lose!");
            gameRunning = false;

            foreach (Cell cell in activeRow.cells)
            {
                cell.UIField.readOnly = true;
            }

            return;
        }

        activeIndexProperty += 1;
        UINavigation.SelectCell(activeRow.cells[0]);
    }
}

using UnityEngine;

public class Game : MonoBehaviour
{
    public string word = "HAPPY";   //The correct answer
    
    public Row activeRow;   //Row of the interface we're guessing

    public Color hot, warm, cold;   //Colour palette

    void Start()
    {
        //GuessWord();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))   //Submit a guess when I press ENTER (Return)
        {
            GuessWord();
        }
    }

    //Retrieve the letters of the currently active row
    public void GuessWord()
    {
        string guess = activeRow.GetWord();

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
    }
}

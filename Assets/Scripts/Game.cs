using UnityEngine;

public class Game : MonoBehaviour
{
    public string word = "HAPPY";
    public string guess = "SHAPE";

    void Start()
    {
        GuessWord();
    }

    public void GuessWord()
    {
        print($"Comparing the word {word} with the word {guess}");

        for (int i = 0; i < 5; i++)
        {
            print($"Comparing {word[i]} against {guess[i]}");

            if (word[i] == guess[i])
            {
                print("<color=green>They match!</color>");
            }

            else if (word.Contains(guess[i]))
            {
                print($"<color=yellow> The word contains the letter {guess[i]} </color>");
            }

            else
            {
                print($"<color=red> The word does not contain the letter {guess[i]} </color>");
            }
        }
    }
}

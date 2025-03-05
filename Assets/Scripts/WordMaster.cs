using System.Collections.Generic;
using UnityEngine;

public class WordMaster : MonoBehaviour
{
    public static List<string> words = new List<string>();  //List of words -- static for accessability
    public bool shuffleOnPlay = false;  //Do we shuffle the list on play?
    public TextAsset textFile;  //What is the txt file we'll analyse

    void Awake()
    {
        ReadAndFilterFile();

        if (shuffleOnPlay)
        {
            ShuffleWords();
        }
    }

    [ContextMenu("Read and Filter File")]   //Allows to run a function in the editor
    public void ReadAndFilterFile() //Extract all the lines split by ' ', ',' and '\n' from the txt file
    {
        words.Clear();

        string[] lines = textFile.text.Split(' ', ',', '\n');

        foreach (string line in lines)  //Filter the words to see if they're 5 chars long, any special chars and any duplicates while making upper case
        {
            if (line.Length != 5)
            {
                continue;
            }

            if (HasSpecialCharacter(line))
            {
                continue;
            }

            if (words.Contains(line.ToUpper()))
            {
                continue;
            }

            words.Add(line.ToUpper());
        }
    }

    public bool HasSpecialCharacter(string word)    //Does the word contain anything other than an alphabetical char?
    {
        foreach (char letter in word)
        {
            if (!char.IsLetter(letter))
            {
                return true;
            }
        }

        return false;
    }

    [ContextMenu("Shuffle Words")]
    public void ShuffleWords()  //Linear shuffle (modified linear sort) to randomise our list
    {
        List<string> shuffledList = new List<string>();
        int count = words.Count;

        for (int i = 0; i < count; i++)
        {
            int randomI = Random.Range(0, words.Count);
            shuffledList.Add(words[randomI]);
            words.RemoveAt(randomI);
        }

        words = shuffledList;
    }

    public static string PopWord()  //Return the top element and move to the bottom of the list / Made static for accessability
    {
        string word = words[0];

        words.RemoveAt(0);
        words.Add(word);

        return word;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordClass
{
    string wordString;
    WordDisplay wordDisplay;
    int typeIndex = 0;

    public WordClass(string _wordString, WordDisplay _wordDisplay, Vector3 positionToSet, Vector3 velocityToSet)
    {
        wordString = _wordString;
        wordDisplay = _wordDisplay;

        wordDisplay.CreateWordDisplay(wordString, positionToSet, velocityToSet);
    }

    public string GetString()
    {
        return wordString;
    }

    public char GetNextChar()
    {
        char tempchar = wordString[typeIndex];
        return tempchar;
    }

    public int GetWordSize()
    {
        int wordSize = wordString.Length;
        return wordSize;
    }

    public void RemoveFirstChar()
    {
        typeIndex++;
        wordDisplay.RemoveLetter();
    }

    public bool ToDestroyWord()
    {
        bool wordTyped = false;
        if (typeIndex >= wordString.Length)
        {
            wordTyped = true;
            wordDisplay.DestroyWord();
        }
        return wordTyped;
    }
}

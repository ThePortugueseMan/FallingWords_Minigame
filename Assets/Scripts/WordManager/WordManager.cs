using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    //Cached Refs
    Canvas gameCanvas;
    ScoreTracker scoreTracker;
    WordSpawner wordSpawner;
    Accuracy accuracy;

    public List<WordClass> currentWords = new List<WordClass>();
    

    bool hasActiveWord = false;
    WordClass activeWord;

    private void Start()
    {
        gameCanvas = FindObjectOfType<Canvas>();
        scoreTracker = FindObjectOfType<ScoreTracker>();
        wordSpawner = GetComponent<WordSpawner>();
        accuracy = FindObjectOfType<Accuracy>();
    }



    public void AddWordToCurrent(WordClass wordToAdd)
    {
        currentWords.Add(wordToAdd);
    }

    public List<WordClass> GetCurrentWordsList()
    {
        return currentWords;
    }

    public void TypeLetter(char inputLetter)
    {        
        if (hasActiveWord == false)
        {
            CompareCurrentWordList(inputLetter);
        }
        else if (activeWord != null)
        {
            CompareActiveWord(inputLetter);
        }
    }

    public void CompareCurrentWordList(char _inputLetter)
    {
        foreach (WordClass tempWord in currentWords)
        {
            if (tempWord.GetNextChar() == _inputLetter)
            {
                tempWord.RemoveFirstChar();
                hasActiveWord = true;
                activeWord = tempWord;
                accuracy.AddToAccurChar();
                ToRemoveActiveWordFromCurrent();
                break;
            }
        }

        //if there's no active word and there's no matching 1st char in the wordlist
        if (!hasActiveWord) 
        { 
            scoreTracker.RemoveScore();
            accuracy.AddToMissChar();
        }
    }

    public void CompareActiveWord (char _inputLetter)
    {
        if (activeWord.GetNextChar() == _inputLetter)
        {
            activeWord.RemoveFirstChar();
            accuracy.AddToAccurChar();
            ToRemoveActiveWordFromCurrent();
        }

        else
        {
            scoreTracker.RemoveScore();
            accuracy.AddToMissChar();
        }
    }

    public bool AreThereActiveWords()
    {
        bool stillActiveWords;
        if ( currentWords.Count == 0)
        {
            stillActiveWords = false;
            return stillActiveWords;
        }

        stillActiveWords = true;
        return stillActiveWords;

    }

    public void ToRemoveActiveWordFromCurrent()
    {
        bool destroyWord = activeWord.ToDestroyWord();

        if (destroyWord == true)
        {
            currentWords.Remove(activeWord);
            hasActiveWord = false;
            scoreTracker.AddScore();
        }
    }
    
}

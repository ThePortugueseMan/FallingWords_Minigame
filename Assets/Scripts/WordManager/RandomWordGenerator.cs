using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RandomWordGenerator : MonoBehaviour
{
    public WordManager wordManager;
    List<string> baseList; 
    List<string> easyList;
    List<string> mediumList;
    List<string> hardList;

    private void Start()
    {
        SetDataBases();
    }

    private void SetDataBases()
    {
        baseList = new List<string>(System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/WordList/" + "TestBase" + ".txt"));
        easyList = new List<string>(System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/WordList/" + "EasyBase" + ".txt"));
        mediumList = new List<string>(System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/WordList/" + "MediumBase" + ".txt"));
        hardList = new List<string>(System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/WordList/" + "HardBase" + ".txt"));
    }

    public string GetWordFromDataBase(List<string> dataBase)
    {
        string _tempWord = dataBase[Random.Range(0, dataBase.Count)];
        return _tempWord;
    }

    public string GetRandomWord()
    {
        string randomWord = GetWordFromDataBase(baseList);
        
        while(IsThereAWordWithTheSameFirstLetter(randomWord)==true)
        {
            randomWord = GetWordFromDataBase(baseList);
        }

        

        return randomWord;
    }

    public string GetEasyWord()
    {
        string tempWord = GetWordFromDataBase(easyList);

        while (IsThereAWordWithTheSameFirstLetter(tempWord) == true)
        {
            tempWord = GetWordFromDataBase(easyList);
        }

        return tempWord;
    }

    public string GetMediumWord()
    {
        string tempWord = GetWordFromDataBase(mediumList);

        while (IsThereAWordWithTheSameFirstLetter(tempWord) == true)
        {
            tempWord = GetWordFromDataBase(mediumList);
        }

        return tempWord;
    }

    public string GetHardWord()
    {

        string tempWord = GetWordFromDataBase(hardList);

        while (IsThereAWordWithTheSameFirstLetter(tempWord) == true)
        {
            tempWord = GetWordFromDataBase(hardList);
        }

        return tempWord;
    }

    public bool IsThereAWordWithTheSameFirstLetter(string wordToCompare)
    {
        List<WordClass> _currentWords = wordManager.GetCurrentWordsList();

        if(_currentWords.Count <=1) 
        {
            return false; 
        }
        
        for (int i = 0; i < _currentWords.Count; i++)
        {
            string tempString = _currentWords[i].GetString();

            if (tempString.Substring(0, 1) == wordToCompare.Substring(0, 1))
            {
                return true;
            }
        }
        return false;
    }

}

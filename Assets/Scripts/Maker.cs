using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Maker : MonoBehaviour
{
    public WordManager wordManager;
    string[] wordDataBase = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/WordList/" + "Common" + ".txt");
    List<string> wordDataList;
    List<string> wordsOfSize = new List<string>();
    int minWordSize = 4;
    int maxWordSize = 5;

    private void Start()
    {
        wordDataList = new List<string>(wordDataBase);
        

        //EliminateDuplicates(wordDataList);

        GetWordsOfSize();
        PrintToNewFile();

    }

    private void GetWordsOfSize()
    {
        int count = 0;
        Debug.Log(wordDataList.Count);
        for (int i = 0; i< wordDataList.Count; i++)
        {
            int temp = wordDataList[i].Length;
            if (minWordSize <= temp && temp <= maxWordSize)
            {
                count++;
                wordsOfSize.Add(wordDataList[i]);
            }
        }

        Debug.Log("c="+count);
    }

    private void PrintToNewFile()
    {
        string[] tempString = wordsOfSize.ToArray();
            System.IO.File.WriteAllLines(Application.streamingAssetsPath + "/WordList/" + "CommonMedEz" + ".txt", tempString);
    }

    public string GetWordFromDataBase(List<string> dataBase)
    {
        string _tempWord = dataBase[Random.Range(0, dataBase.Count)];
        return _tempWord;
    }

    public void EliminateDuplicates(List<string> _database)
    {
        for (int i = 0; i < _database.Count; i++)
        {
            string tempWord = _database[i];
            for (int j = i+1; j < _database.Count; j++)
            {
                if(_database[i] == _database[j])
                {
                    Debug.Log(_database[i]+"-"+i+ "=" + _database[j]+"-"+j);
                    _database.RemoveAt(j);
                }
            }
        }
    }
}

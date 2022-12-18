using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWaveIndex = 0;
    [SerializeField] GameObject wordPrefab;
    [SerializeField] WordManager wordManager;
    [SerializeField] RandomWordGenerator randomWordGenerator;
    Canvas gameCanvas;

    [SerializeField] bool looping = false;

    IEnumerator Start()
    {
        gameCanvas = FindObjectOfType<Canvas>();

        do
        {
            yield return StartCoroutine("SpawnAllWaves");
        }

        while (looping);
        FindObjectOfType<SceneLoader>().LoadGameOverScene();
    }


    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWaveIndex; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllWordsInWave(currentWave,waveIndex));
        }
    }

    private IEnumerator SpawnAllWordsInWave(WaveConfig waveConfig, int _waveIndex)
    {
          yield return StartCoroutine(StartWaveMessage(_waveIndex));

        int difficultyIndex = 0;
        List<int> difficultyList = new List<int>();
        string wordToSet = "";
        int easyWords = waveConfig.GetNumberOfEasyWords();
        int mediumWords = waveConfig.GetNumberOfMediumWords();
        int hardWords = waveConfig.GetNumberOfHardWords();

        SetDifficultyList(difficultyList, easyWords, mediumWords, hardWords);

        for (int wordCount = 0; wordCount < waveConfig.GetNumberOfWordsInWave(); wordCount++)
        {
            Vector3 startPosition = GetSpawnPosition();
            
            difficultyIndex = GetDifficultyIndex(difficultyList);

            switch(difficultyIndex)
            {
                case 0:
                    wordToSet = randomWordGenerator.GetEasyWord();
                    easyWords--;
                    break;
                case 1:
                    wordToSet = randomWordGenerator.GetMediumWord();
                    mediumWords--;
                    break;
                case 2:
                    wordToSet = randomWordGenerator.GetHardWord();
                    hardWords--;
                    break;
                default:
                    Debug.Log("HOW");
                    break;
            }

            UpdateDifficultyList(difficultyList, easyWords, mediumWords, hardWords);

            var newWord = CreateNewWord(
                gameCanvas.transform,
                startPosition,
                waveConfig.GetFallSpeed(), 
                wordToSet);

            wordManager.AddWordToCurrent(newWord);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());

        }


        while (wordManager.AreThereActiveWords() == true)
        {
            yield return null;
        }


        yield return new WaitForSeconds(0.5f);

    }

    private void SetDifficultyList(List<int> _difficultyList, int _easyWords, int _mediumWords, int _hardWords)
    {
        _difficultyList.Clear();

        if (_easyWords > 0)
        {
            _difficultyList.Add(0);
        }

        if(_mediumWords > 0)
        {
            _difficultyList.Add(1);
        }

        if(_hardWords > 0)
        {
            _difficultyList.Add(2);
        }


    }

    private void UpdateDifficultyList(List<int> _difficultyList, int _easyWords, int _mediumWords, int _hardWords)
    {
        if (_easyWords <= 0 )
        {
            for (int i = 0; i < _difficultyList.Count; i++)
            {
                if (_difficultyList[i] == 0)
                {
                    _difficultyList.RemoveAt(i);
                    break;
                }
            }
        }

        if (_mediumWords <= 0)
        {
            for (int i = 0; i < _difficultyList.Count; i++)
            {
                if (_difficultyList[i] == 1)
                {
                    _difficultyList.RemoveAt(i);
                    break;
                }
            }
        }

        if (_hardWords <= 0)
        {
            for (int i = 0; i < _difficultyList.Count; i++)
            {
                if (_difficultyList[i] == 2)
                {
                    _difficultyList.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private int GetDifficultyIndex(List<int> _difficultyList)
    {
        int difficultyIndex = _difficultyList[Random.Range(0, _difficultyList.Count)];

        return difficultyIndex;
    }

    private IEnumerator StartWaveMessage(int _waveIndex)
    {
        _waveIndex++;                                                                               //for display purposes
        Vector3 midPos = new Vector3(350f, 220f, 0f);
        Vector3 nullVel = new Vector3(0f, 0f, 0f);
        string display = "Wave  " + _waveIndex.ToString();
        GameObject messageObject = Instantiate(wordPrefab, gameCanvas.transform);
        WordDisplay messageWordDisplay = messageObject.GetComponent<WordDisplay>();
        
        messageWordDisplay.SetFontSize(80f);
        WordClass messageWord = new WordClass(display, messageWordDisplay, midPos, nullVel);
        
        yield return new WaitForSeconds(2.5f);
        Destroy(messageObject);

    }


    private Vector3 GetSpawnPosition()
    {
        /*xMin = 45;
         xMax = 730;
         yStart = 495;
         fallSpeed = 50f;*/
        Vector3 spawnVector;
        spawnVector = new Vector3(Random.Range(45, 730), 495, 0f);
        return spawnVector;

    }

    public WordClass CreateNewWord(Transform parent, Vector3 _startPosition, float _fallSpeed, string _wordToSet)
    {
        Vector3 startVelocity = new Vector3(0f, -_fallSpeed, 0f);
        GameObject wordObject = Instantiate(wordPrefab, parent);

        WordClass tempWord = 
            new WordClass (_wordToSet,
            wordObject.GetComponent<WordDisplay>(),
            _startPosition,
            startVelocity);


        return tempWord;
    }

}

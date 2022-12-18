using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="Wave Configs")]
public class WaveConfig : ScriptableObject
{
    public float timeBetweenSpawns;
    public float fallSpeed;
    public float randomFactor;
    public int numberOfWords;
    public int easyWords;
    public int mediumWords;
    public int hardWords;


    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }

    public int GetNumberOfWordsInWave() { return numberOfWords; }

    public int GetNumberOfEasyWords() { return easyWords; }

    public int GetNumberOfMediumWords() { return mediumWords; }

    public int GetNumberOfHardWords() { return hardWords; }

    public float GetFallSpeed() { return fallSpeed; }

    public float GetRandomFactor() { return randomFactor; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Accuracy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textComponent;

    int accurChar = 0;
    int missChar = 0;
    int totalTyped = 0;
    float accuracy = 0;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        textComponent.text = "100.00%";
    }
    public void AddToAccurChar()
    {
        accurChar++;
        totalTyped++;
        UpdateDisplay();
    }

    public void AddToMissChar()
    {
        missChar++;
        totalTyped++;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        accuracy = ((float)accurChar / (float)totalTyped) * 100f;

        textComponent.text = accuracy.ToString("0.00")+"%";
    }
    public float GetAccuracy()
    {
        float accuracy = 0;
        accuracy = (accurChar / (accurChar + missChar)) * 100;
        return accuracy;
    }
}

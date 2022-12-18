using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordDisplay : MonoBehaviour
{
    //Cached refs
    public TextMeshProUGUI textComponent;
    public Transform transformComponent;
    public Rigidbody2D rigidBodyComponent;
    public float fontSize;

    
    public void CreateWordDisplay(string wordToSet, Vector3 positionToSet, Vector3 velocityToSet)
    {
        textComponent.text = wordToSet;
        transformComponent.localScale = new Vector3 (1f, 1f, 1f);
        transformComponent.position = positionToSet;
        rigidBodyComponent.velocity = velocityToSet;
    }

    public void SetFontSize(float fontSize)
    {
        textComponent.fontSize = fontSize;
    }

    public void RemoveLetter()
    {
        textComponent.text = textComponent.text.Remove(0, 1);
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    public void DestroyWord()
    {
        Destroy(gameObject);
    }
}

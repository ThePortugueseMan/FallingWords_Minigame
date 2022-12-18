using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] WordManager wordManager;

    void Update()
    {
            foreach (char letter in Input.inputString)
            {
                char newLetter = char.ToLower(letter);
                wordManager.TypeLetter(newLetter);
            }
    }

}

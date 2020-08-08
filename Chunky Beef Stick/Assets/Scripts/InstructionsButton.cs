using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsButton : MonoBehaviour
{
    [SerializeField] GameObject InstructionsScreen; 
    public void LoadInstructions() {
        InstructionsScreen.SetActive(true);
    }
}

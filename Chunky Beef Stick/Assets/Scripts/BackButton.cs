using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] GameObject InstructionsScreen;

    public void HideInstructions() {
        InstructionsScreen.SetActive(false);
    }
}

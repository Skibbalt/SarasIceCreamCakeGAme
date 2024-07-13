using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    EyeSpy_Instructions instructions; //Referencing the "EyeSpy_Instructions" script

    [SerializeField]
    private GameObject transistionUI;

    void Awake()
    {
        transistionUI.SetActive(false);
    }

    void Update()
    {
        if(instructions.InstructionsFulfilled() == true)
            transistionUI.SetActive(true);
    }
}

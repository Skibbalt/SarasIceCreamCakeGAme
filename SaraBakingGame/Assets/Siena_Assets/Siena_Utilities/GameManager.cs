using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject [] destroyableIngredients;

    [SerializeField]
    private GameObject transistionUI;

    private int counter = 0; //This variable is to iterate through the "destroyableIngredients" array

    void Awake()
    {
        transistionUI.SetActive(false);
    }

    void Update() //Using the <,> signs to prevent out of bounds error
    {
        if(counter >= destroyableIngredients.Length)
            transistionUI.SetActive(true);

        if(counter < destroyableIngredients.Length && destroyableIngredients[counter] == null) //Order for conditions in "if" statements MATTER!
            counter++;
    }
}

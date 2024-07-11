using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ingredients_Instructions : MonoBehaviour
{
    [SerializeField]
    private string [] playerInstructions;

    [SerializeField]
    private IngredientButton [] ingredientButton; //Referring to the "IngredientButton" script that are attached to UI buttons in the scene under MainUICanvas

    private bool giveOutACommand = false;
    private int counter = 0; //int increment for going up indexes for the "playerInstructions" array

    void Start()
    {
        giveOutACommand = true;
    }

    void Update() //I have to fix this script because there's issues with "counter" and how it increases" 
    {
        if(giveOutACommand == true)
        {
            GiveInstructions(counter);
            giveOutACommand = false;
        }

        if(ingredientButton[counter].hasBeenPressed == true && counter == ingredientButton[counter].buttonIndex)
        {
            if(counter == (playerInstructions.Length-1) && ingredientButton[counter].buttonIndex == counter)
                Destroy(this.gameObject);

            giveOutACommand = true;
            counter++;
        }
    }

    private void GiveInstructions(int chosenInstruction)
    {
        Debug.Log(playerInstructions[chosenInstruction]);
    }
}

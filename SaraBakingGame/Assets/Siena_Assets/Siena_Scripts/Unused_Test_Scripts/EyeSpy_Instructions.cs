using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Coded by Siena. I know arrays are costly, I'm sorry. I'll try to figure out if there's a better way to destroy the game object.

public class EyeSpy_Instructions : MonoBehaviour 
{
    [SerializeField]
    private string [] playerInstructions;

    [SerializeField]
    private GameObject [] ingredients;

    private bool giveOutACommand = false; //This bool will be switched to true when needing to move to the next index in the "playerInstructions" array
    private bool instructionsCompleted = false; //This bool will be switched to true IF all the indexes from "playerInstructions" have been gone through
    private int counter = 0; //int increment for going up indexes for the "playerInstructions" array

    void Awake()
    {
        Debug.Log(playerInstructions[counter]);
    }

    void Update()
    {
        if(giveOutACommand == true)
        {
            Destroy(ingredients[counter-1]); //"counter" here as to be minus by one in order for the correct gameObject in the "ingredients" array to be destroyed
            GiveInstructions(counter);
            giveOutACommand = false;
        }

        if(counter == playerInstructions.Length)
        {
            Destroy(this.gameObject);
            instructionsCompleted = true;
        }
    }

    public bool InstructionsFulfilled() //This method will be called by the "GameManager" script
    {
        return instructionsCompleted;
    }

    public void checkIndexes(int ingredientIndex) //Grabbing an int reference from the "Base_Ingredient" script
    {
        if(ingredientIndex == counter)
        {
            giveOutACommand = true;
            counter++;
        }
    }

    void GiveInstructions(int playerInstructionsIndex)
    {
        if(counter < (playerInstructions.Length))
            Debug.Log(playerInstructions[playerInstructionsIndex]);
    }
}

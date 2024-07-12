using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivingInstructions : MonoBehaviour
{
    [HideInInspector]
    public int givenIngredientIndex;

    [SerializeField]
    private string [] playerInstructions;

    private bool giveOutACommand = false;
    private int counter = 0; //int increment for going up indexes for the "playerInstructions" array

    void Awake()
    {
        giveOutACommand = true;
    }

    void Update()
    {
        if(givenIngredientIndex == counter)
        {
            giveOutACommand = true;
            counter++;
        }

        if(giveOutACommand == true)
        {
            GiveInstructions(counter);
            giveOutACommand = false;
        }

        if(counter == playerInstructions.Length)
            Destroy(this.gameObject);
    }

    void GiveInstructions(int playerInstructionsIndex)
    {
        if(counter < (playerInstructions.Length))
            Debug.Log(playerInstructions[playerInstructionsIndex]);
    }
}

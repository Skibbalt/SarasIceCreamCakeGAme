using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collectable_B_Ingredients : MonoBehaviour
{
    [SerializeField]
    private Button [] ingredientToCollect;

    [SerializeField]
    private Transform [] ingredientPositions;

    private int randomPositionSpot;

    void Awake()
    {
        PlaceIngredientsRandomly();
    }   
    
    private void PlaceIngredientsRandomly()
    {
        for(int i = 0; i < ingredientToCollect.Length; i++) //Iterating through the "ingredientToCollect" array indexes
        {
            do
            {
                randomPositionSpot = Random.Range(0, ingredientPositions.Length);

            }while(ingredientPositions[randomPositionSpot] == null); 
            //This while loop has two functions: 
            //1. To keep generating random numbers in coorelation with re-iterating through the "ingredientsPosition" array indexes 
            //2. To also continously check through the "ingredientsPosition" array indexes, seeing if those indexes are null or not

            ingredientToCollect[i].transform.position = ingredientPositions[randomPositionSpot].transform.position;
            ingredientPositions[randomPositionSpot] = null;
        }
    }
}

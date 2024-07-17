using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Coded by Siena

public class Baking_Ingredient : Base_Ingredient
{
    public int ingredientIndex;

    void Awake()
    {
        givenIngredientIndex = ingredientIndex;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class An_Ingredient : GivingInstructions, IPointerDownHandler
{
    public int ingredientIndex;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("I have been clicked");
        givenIngredientIndex = ingredientIndex;
    }
}

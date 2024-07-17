using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

//Coded by Siena

public class Base_Ingredient : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField]
    EyeSpy_Instructions instructions; //Referencing the "EyeSpy_Instructions" script

    [HideInInspector]
    public int givenIngredientIndex; //This value will be assigned from the "Baking_Ingredient" script

    public void OnPointerDown(PointerEventData eventData)
    {
        instructions.checkIndexes(givenIngredientIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientButton : MonoBehaviour //This script is attached to buttons in the scene under "Buttons_For_Ingredients_Interactions"
{
    public int buttonIndex = 0;
    public bool hasBeenPressed = false;

    public void OnHasBeenPressedByMouse()
    {
        hasBeenPressed = true;
    }
}

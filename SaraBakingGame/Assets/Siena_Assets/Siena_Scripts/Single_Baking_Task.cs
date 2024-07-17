using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class Single_Baking_Task : MonoBehaviour, IPointerDownHandler 
{
    public Baking_Manager bakingManager; //Referring to the "Baking_Manager" script
    public string nameOfBakingItem; //This variable will be passed to the "Baking_Manager" script

    public void OnPointerDown(PointerEventData eventData)
    {
        bakingManager.recievedIngredient = nameOfBakingItem;
        Invoke("DestroySelf", 0.5f); //Calling "DestroySelf" method after 0.5 seconds pass
    }

    private void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}

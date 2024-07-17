using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    private DragAndDrop dragAndDrop;

    private void Awake()
    {
        // Get the DragAndDrop component attached to the same GameObject
        dragAndDrop = GetComponent<DragAndDrop>();

        if (dragAndDrop == null)
        {
           
        }
    }

    public void EnableDragging()
    {
        if (dragAndDrop != null)
        {
            dragAndDrop.SetDraggable(true);
        }
    }

    public void DisableDragging()
    {
        if (dragAndDrop != null)
        {
            dragAndDrop.SetDraggable(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Counter1"))
        {
            DisableDragging();
        }
       
       
    }

}

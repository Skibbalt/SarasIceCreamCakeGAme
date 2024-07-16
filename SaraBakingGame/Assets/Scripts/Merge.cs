
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Merge : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDraggable = true; // Boolean flag to control dragging
    private bool isDragging = false; // Flag to check if the object is being dragged

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isDraggable) return; // Check if dragging is enabled
        UnityEngine.Debug.Log("Down");
        offset = transform.position - GetMouseWorldPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDraggable) return; // Check if dragging is enabled
        UnityEngine.Debug.Log("Begin Drag");
        isDragging = true; // Set dragging flag to true
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return; // Check if dragging is enabled
        transform.position = GetMouseWorldPosition() + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable) return; // Check if dragging is enabled
        UnityEngine.Debug.Log("End Drag");
        isDragging = false; // Set dragging flag to false
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10.0f; // distance from the camera to the object
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    // Method to enable or disable dragging
    public void SetDraggable(bool draggable)
    {
        isDraggable = draggable;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameObjectName;
        string collisionGameObjectName;

        // Check if the underscore is present in the names
        int thisGameObjectNameIndex = gameObject.name.IndexOf("_");
        int collisionGameObjectNameIndex = collision.gameObject.name.IndexOf("_");

        if (thisGameObjectNameIndex > 0 && collisionGameObjectNameIndex > 0)
        {
            thisGameObjectName = gameObject.name.Substring(0, thisGameObjectNameIndex);
            collisionGameObjectName = collision.gameObject.name.Substring(0, collisionGameObjectNameIndex);

            if (!isDragging && thisGameObjectName == "Egg" && thisGameObjectName == collisionGameObjectName)
            {
                Instantiate(Resources.Load("EggBowl"), transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
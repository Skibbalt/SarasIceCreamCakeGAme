using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDraggable = true; // Boolean flag to control dragging

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
}
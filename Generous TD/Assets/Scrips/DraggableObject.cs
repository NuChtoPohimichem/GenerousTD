using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 touchOffset;
    private void OnMouseDown()
    {
        isDragging = true;
        touchOffset = transform.position - GetMouseWorldPosition();
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 20; // distance from the camera
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    private void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + touchOffset;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSprite : MonoBehaviour
{
    private void Update()
    {
        ChaseCursor();
    }

    private void ChaseCursor()
    {
        transform.position = new Vector2(GetMousePosition().x - 0.2f, GetMousePosition().y);
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

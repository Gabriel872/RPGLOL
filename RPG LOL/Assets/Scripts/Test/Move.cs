using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    protected bool canMove;
    protected Vector3 mouseOffSet;
    protected string currentLayer;
    protected bool doSomething;

    protected virtual void FixedUpdate()
    {
        currentLayer = GameManager.instance.layer;
    }

    protected virtual void OnMouseDown()
    {
        if (canMove)
        {
            mouseOffSet = gameObject.transform.position - GetMousePosition();
        }
    }

    protected virtual void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mouseOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mouseOffSet.y));
        }
    }

    protected virtual void OnMouseOver()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                doSomething = true;
            }
        }
    }

    protected virtual Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

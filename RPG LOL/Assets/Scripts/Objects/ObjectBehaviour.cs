using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private int _sprRen;
    private Vector3 mOffSet;
    
    private bool canMove;

    private void Start()
    {
        _sprRen = GetComponent<SpriteRenderer>().sortingOrder;
    }

    private void Update()
    {
        if (GameManager.instance.layer.Equals("objects") && GameManager.instance.sortingLayer.Equals(_sprRen))
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    private void OnMouseDown()
    {
        if (canMove)
        {
            mOffSet = gameObject.transform.position - GetMousePosition();
        }
    }

    private void OnMouseOver()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + 90f);
            }

            if (Input.GetKeyDown(KeyCode.Equals))
            {
                transform.GetComponent<SpriteRenderer>().sortingOrder++;
            }

            if (Input.GetKeyDown(KeyCode.Minus))
            {
                transform.GetComponent<SpriteRenderer>().sortingOrder--;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mOffSet.y));
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

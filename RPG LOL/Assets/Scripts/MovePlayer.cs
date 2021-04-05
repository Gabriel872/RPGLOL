using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Sprite spr;

    private SpriteRenderer sprR;

    private Vector3 mOffSet;

    private void Start()
    {
        sprR = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        mOffSet = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mOffSet.y));

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder++;
        }

        if (Input.GetKeyDown(KeyCode.Minus))
        {
            transform.GetComponent<SpriteRenderer>().sortingOrder--;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            sprR.sprite = spr;
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
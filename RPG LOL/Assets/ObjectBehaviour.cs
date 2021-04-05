using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private Vector3 mOffSet;

    private void OnMouseDown()
    {
        mOffSet = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseOver()
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

    private void OnMouseDrag()
    {
        transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mOffSet.y));
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

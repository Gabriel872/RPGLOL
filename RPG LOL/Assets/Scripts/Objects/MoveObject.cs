using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class MoveObject : MonoBehaviour
{
    public TextMeshProUGUI namePlayer;
    public TextMeshProUGUI vida;

    public SpriteRenderer spr;

    private Vector3 mOffSet;

    private bool canMove;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.instance.layer.Equals("NPC"))
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
            FunctionBar.funBar.GetObject(this);
            mOffSet = gameObject.transform.position - GetMousePosition();
        }
    }

    private void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mOffSet.y));

            if (Input.GetKeyDown(KeyCode.T))
            {
                Destroy(this.gameObject);
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

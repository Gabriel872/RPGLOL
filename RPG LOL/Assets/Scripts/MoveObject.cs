using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class MoveObject : MonoBehaviour
{
    public TextMeshProUGUI namePlayer;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI vida;

    public GameObject button;

    public SpriteRenderer spr;

    private Vector3 mOffSet;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        FunctionBar.funBar.GetObject(this);
        mOffSet = gameObject.transform.position - GetMousePosition();
    }

    private void OnMouseDrag()
    {
        transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mOffSet.y));

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(this.gameObject);
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

}

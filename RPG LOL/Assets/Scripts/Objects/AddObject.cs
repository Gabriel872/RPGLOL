using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObject : MonoBehaviour
{
    [SerializeField] private Transform _objectSprite;
    [SerializeField] private SpriteRenderer sprCursorChaser;

    [Space]
    [Space]

    [SerializeField] private List<Sprite> _spriteList;

    private int value = 0;

    private void Start()
    {
        if (sprCursorChaser != null)
        {
            sprCursorChaser.sprite = _spriteList[value];
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            Add();
        }
        if (Input.GetMouseButtonDown(2))
        {
            if (value >= (_spriteList.Count - 1))
            {
                value = 0;
            }
            else
            {
                value++;
            }
            if (sprCursorChaser != null)
            {
                sprCursorChaser.sprite = _spriteList[value];
            }
        }
    }

    private void Add()
    {
        Transform img = Instantiate(_objectSprite, new Vector3(Mathf.RoundToInt(GetMousePosition().x), Mathf.RoundToInt(GetMousePosition().y), GetMousePosition().z), Quaternion.identity);
        img.GetComponent<SpriteRenderer>().sprite = _spriteList[value];
        img.gameObject.AddComponent<PolygonCollider2D>();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        Debug.Log(Camera.main.ScreenToWorldPoint(mousePos));
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

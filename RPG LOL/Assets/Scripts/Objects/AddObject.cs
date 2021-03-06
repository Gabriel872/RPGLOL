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

    public bool subs;

    private int value = 0;
    private Vector3 previousPosition = new Vector3();
    private Vector3 mousePos;
    private int sortingLayer;
    private string _addLayer;
    private GameObject subsObj;

    private void Start()
    {
        previousPosition = new Vector3(0f, 0f, 0f);

        if (sprCursorChaser != null)
        {
            sprCursorChaser.sprite = _spriteList[value];
        }
    }

    private void Update()
    {
        _addLayer = GameManager.instance.layer;

        if (Input.GetMouseButton(1) && _addLayer.Equals("objects"))
        {
            Add();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            sortingLayer++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
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

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (value < 1)
            {
                value = 10;
            }
            else
            {
                value--;
            }
            if (sprCursorChaser != null)
            {
                sprCursorChaser.sprite = _spriteList[value];
            }
        }
    }

    private void Add()
    {
        mousePos = new Vector3(Mathf.RoundToInt(GetMousePosition().x), Mathf.RoundToInt(GetMousePosition().y), GetMousePosition().z);

        if (mousePos != previousPosition && !subs)
        {
            previousPosition = mousePos;
            Transform img = Instantiate(_objectSprite, mousePos, Quaternion.identity);
            img.GetComponent<SpriteRenderer>().sortingOrder = GameManager.instance.sortingLayer;
            img.GetComponent<SpriteRenderer>().sprite = _spriteList[value];
            img.gameObject.AddComponent<PolygonCollider2D>();
        }
        else if (subs && subsObj != null) 
        {
            if (subsObj.GetComponent<SpriteRenderer>().sortingOrder.Equals(GameManager.instance.sortingLayer)) 
            { 
                subsObj.GetComponent<SpriteRenderer>().sprite = _spriteList[value];        
            }
        }

        subs = false;
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void Substitui(GameObject go_subs) 
    {
        subs = true;
        subsObj = go_subs;
    }
}

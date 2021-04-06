﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private Sprite spr;

    private SpriteRenderer sprR;

    private Vector3 mOffSet;

    private bool canMove;

    private void Start()
    {
        sprR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GameManager.instance.layer.Equals("Player"))
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

    private void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position = new Vector2(Mathf.RoundToInt(GetMousePosition().x + mOffSet.x), Mathf.RoundToInt(GetMousePosition().y + mOffSet.y));

            if (Input.GetKeyDown(KeyCode.R))
            {
                sprR.sprite = spr;
            }
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}
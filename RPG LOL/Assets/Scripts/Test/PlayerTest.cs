using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : Character
{
    [SerializeField] private Sprite playerAlive;
    [SerializeField] private Sprite playerDied;
    private SpriteRenderer spriteRenderer;

    public int id;

    private void Start()
    {
        lifeCharacter = 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(GetStats());
        if(lifeCharacter <= 0)
        {
            spriteRenderer.sprite = playerDied;
        }
    }

    protected override void OnMouseOver()
    {
        base.OnMouseOver();
        if (doSomething)
            PlayerStabilized();
    }

    private void PlayerStabilized()
    {
        if (!spriteRenderer.sprite.Equals(playerAlive))
        {
            lifeCharacter = 1;
            spriteRenderer.sprite = playerAlive;
        }
    }
}
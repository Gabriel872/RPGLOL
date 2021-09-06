using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Move
{
    protected int lifeCharacter = 0;
    protected string nameCharacter = "Name";

    public int GetStats()
    {
        return lifeCharacter;
    }

    public void SetLife(int life)
    {
        lifeCharacter = life;
    }

    public string GetName()
    {
        return nameCharacter;
    }

    public void SetName(string name)
    {
        nameCharacter = name;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (currentLayer.Equals("Player"))
            canMove = true;
        else
            canMove = false;
    }
}

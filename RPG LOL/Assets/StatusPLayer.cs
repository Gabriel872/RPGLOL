using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusPLayer : MonoBehaviour
{
    private int _life = 10;
    private string _nick = "Player";



    public int getLife()
    {
        return _life;
    }

    public void setLife(int newLife)
    {
        _life = newLife;
    }

    public string getNick()
    {
        return _nick;
    }

    public void setNick(string newNick)
    {
        _nick = newNick;
    }
}

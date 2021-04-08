using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public Animator animButton;
    public bool huge;

    public void GrowUp()
    {
        if (!huge)
        {
            animButton.Play("animButton");
            huge = true;
        }
        else
        {
            animButton.Play("animButton2");
            huge = false;
        }
    }

    public void Idle()
    {
        animButton.Play("idleButton");
    }
}

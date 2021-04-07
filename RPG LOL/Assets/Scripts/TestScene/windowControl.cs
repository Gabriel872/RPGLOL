using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowControl : MonoBehaviour
{
    [SerializeField] private GameObject window;

    private Animator anim;

    private void Start()
    {
        anim = window.GetComponent<Animator>();
    }

    public void WidowOperation()
    {
        if (window.activeSelf)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        if (anim == null)
        {
            return;
        }
        else
        {
            window.SetActive(true);
            anim.Play("Window");
        }
    }

    private void Close()
    {
        if (anim == null)
        {
            return;
        }
        else
        {
            anim.Play("windowClose");
            Invoke("FinishOperations", 1f);
        }
    }

    private void FinishOperations()
    {
        window.SetActive(false);
    }
}

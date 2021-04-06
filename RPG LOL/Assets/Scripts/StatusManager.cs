using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _life;
    [SerializeField] private SpriteRenderer sprPlayer;
    [SerializeField] private Sprite spr;

    private string a = "";

    public void ChangeLife(TextMeshProUGUI _input)
    {
        _life.text = _input.text;
        a = _input.text.ToString();

        if (a == "0")
        {
            Debug.Log(a);
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        sprPlayer.sprite = spr;
    }
}

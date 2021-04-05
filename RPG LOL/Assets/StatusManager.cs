using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _life;
    [SerializeField] private SpriteRenderer sprPlayer;
    [SerializeField] private Sprite spr;
 
    public void ChangeLife(TextMeshProUGUI _input)
    {
        _life.text = _input.text;
        string a = _input.text;

        int.TryParse(a, out int b);
        if (b.Equals(0))
        {
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        sprPlayer.sprite = spr;
    }
}

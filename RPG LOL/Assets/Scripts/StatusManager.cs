using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _life;
    [SerializeField] private TMP_InputField _textInput;
    [SerializeField] private SpriteRenderer _sprPlayer;
    [SerializeField] private Sprite _spr;

    public void SetNull()
    {
        _life.text = "";
        _textInput.text = "";
        _textInput.Select();
    }

    public void ChangeLife(TMP_InputField _input)
    {
        _life.text = _input.text;

        int checkLife;
        checkLife = int.Parse(_life.text);

        if (checkLife.Equals(0))
        {
            ChangeSprite();
        }
    }

    private void ChangeSprite()
    {
        _sprPlayer.sprite = _spr;
    }
}

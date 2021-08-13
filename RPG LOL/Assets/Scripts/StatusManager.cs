using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _life;
    [SerializeField] private TMP_InputField _lifeInput;
    [SerializeField] private SpriteRenderer _spriteRendPlayer;
    [SerializeField] private Sprite _deathSprite;

    public void SetNull()
    {
        _life.text = "";
        _lifeInput.text = "";
        _lifeInput.Select();
    }

    public void ChangeLife(TMP_InputField _input)
    {
        _life.text = _input.text;

        if (_life.text.Equals("") || _life.text.Equals(" "))
        {
            ChangeSprite();
            _life.text = "0";
        }
        else
        {
            int life = int.Parse(_life.text);

            if (life <= 0)
            {
                ChangeSprite();
            }
        }
    }

    private void ChangeSprite()
    {
        if (_deathSprite == null)
        {
            return;
        }

        _spriteRendPlayer.sprite = _deathSprite;
    }
}

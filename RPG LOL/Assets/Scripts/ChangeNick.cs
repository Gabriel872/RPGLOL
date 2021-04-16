using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeNick : MonoBehaviour
{
    [SerializeField] TMP_InputField _inputNick;
    [SerializeField] TextMeshProUGUI _textNick;
    public void SetNull()
    {
        _textNick.text = null;
        _inputNick.text = "";
        _inputNick.Select();
    }

    public void Nick(TMP_InputField _input)
    {
        _textNick.text = _input.text;
    }
}

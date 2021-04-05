using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using TMPro;

public class FunctionBar : MonoBehaviour
{
    [SerializeField] private List<Sprite> _sprNPC;

    private MoveObject _objectSelected;
    private GridManager _gridManager;

    public static FunctionBar funBar;

    private int counter = 0;

    private void Start()
    {
        funBar = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            DecreaseLife();
        }

        if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            AddLife();
        }

        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            ChangeColor();
        }
    }

    public void GetObject(MoveObject objectSelect)
    {
        _objectSelected = objectSelect;
    }

    #region SetTag

    public void ChangeName(TMP_InputField inputName)
    {
        if (_objectSelected != null)
        {
            if (inputName.text.Equals(""))
            {
                _objectSelected.namePlayer.text = "Name";
            }
            else if (_objectSelected != null)
            {
                _objectSelected.namePlayer.text = inputName.text;
            }
        }
    }

    #endregion

    #region SetLife
    public void ChangeLife(TMP_InputField inputLife)
    {
        if (inputLife != null && _objectSelected != null)
        {
            _objectSelected.vida.text = inputLife.text;
        }
    }
    #endregion

    #region +life or -life

    public void AddLife()
    {
        if (_objectSelected != null)
        {
            int addLife = int.Parse(_objectSelected.vida.text);
            addLife++;
            _objectSelected.vida.text = addLife.ToString();
        }
    }

    public void DecreaseLife()
    {
        if (_objectSelected != null)
        {
            int decreaseLife = int.Parse(_objectSelected.vida.text);
            decreaseLife--;
            _objectSelected.vida.text = decreaseLife.ToString();
        }
    }

    #endregion

    #region SetGrid
    public void GetGrid(GridManager grid)
    {
        _gridManager = grid;
    }

    public void SetValuesPlaceHolderRows(TextMeshProUGUI placeHolderRows)
    {
        placeHolderRows.text = _gridManager.rows.ToString();
    }

    public void SetValuesPlaceHolderColumns(TextMeshProUGUI placeHolderColumns)
    {
        placeHolderColumns.text = _gridManager.rows.ToString();
    }

    public void SetValuesRows(TMP_InputField inputRows)
    {
        _gridManager.rows = int.Parse(inputRows.text);
        _gridManager.Grid();
    }

    public void SetValuesColumns(TMP_InputField inputColumn)
    {
        _gridManager.column = int.Parse(inputColumn.text);
        _gridManager.Grid();
    }
    #endregion

    #region ChangeColor
    public void ChangeColor()
    {
        if(counter < (_sprNPC.Count - 1))
        {
            counter++;
        }
        else
        {
            counter = 0;
        }

        if(counter == 0)
        {
            _objectSelected.spr.sprite = _sprNPC[0];
        }
        else if(counter == 1)
        {
            _objectSelected.spr.sprite = _sprNPC[1];
        }
        else if(counter == 2)
        {
            _objectSelected.spr.sprite = _sprNPC[2];
        }
    }
    #endregion
}

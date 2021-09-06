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
        if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeSprite();
        }
    }

    public void GetObject(MoveObject objectSelect)
    {
        _objectSelected = objectSelect;
    }

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

    public void ChangeLife(TMP_InputField inputLife)
    {
        if (inputLife != null && _objectSelected != null)
        {
            _objectSelected.vida.text = inputLife.text;
        }
    }

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

    public void ChangeSprite()
    {
        if (counter < (_sprNPC.Count - 1))
        {
            counter++;
        }
        else
        {
            counter = 0;
        }

        switch (counter)
        {
            case 0:
                _objectSelected.spr.sprite = _sprNPC[0];
                counter = 0;
                break;
            case 1:
                _objectSelected.spr.sprite = _sprNPC[1];
                counter = 0;
                break;
            case 2:
                _objectSelected.spr.sprite = _sprNPC[2];
                counter = 0;
                break;
            default:
                Debug.LogError("erro_spr");
                counter = 0;
                break;
        }
    }
}
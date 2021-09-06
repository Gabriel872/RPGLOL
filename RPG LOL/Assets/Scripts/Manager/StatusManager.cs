using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifeField;
    [SerializeField] private TMP_InputField inputLife;
    [SerializeField] private TextMeshProUGUI nameField;
    [SerializeField] private TMP_InputField inputName;

    private GameManager GM;

    public int id;

    private void Start()
    {
        GM = GameManager.instance;
    }

    public void setnull(bool life)
    {
        if (life)
        {
            lifeField.text = "";
            inputLife.text = "";
            inputLife.Select();
        }
        else
        {
            nameField.text = "";
            inputName.text = "";
            inputName.Select();
        }
        
    }

    public void Rename(TMP_InputField inputNameTMP)
    {
        string name = inputNameTMP.text;
        GM.playerArray.Find(x => x.id == id).SetName(name);
        UpdatePlayersUI();
    }

    public void UpdatePlayerUI(TMP_InputField inputLifeTMP)
    {
        if (inputLifeTMP != null)
        {
            int life = int.Parse(inputLifeTMP.text);
            GM.playerArray.Find(x => x.id == id).SetLife(life);
            UpdatePlayersUI();
        }
        else
        {
            return;
        }
    }

    public void UpdatePlayersUI()
    {
        lifeField.text = GM.playerArray.Find(x => x.id == id).GetStats().ToString();
        nameField.text = GM.playerArray.Find(x => x.id == id).GetName().ToString();
    }
}

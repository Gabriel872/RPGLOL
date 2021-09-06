using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NpcEditor : MonoBehaviour
{
    public static NpcEditor instance;

    [SerializeField] private TMP_InputField inputLife, inputName;

    [Space(20)]

    private Npc npcSelected;
    public GameObject GO;

    private int npcLife;
    private int inputNpcLife;
    private string npcName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void GetNpc(Npc npc)
    {
        npcSelected = npc;
        npcLife = npcSelected.GetStats();
        Debug.Log(npcLife);
        npcName = npcSelected.GetName();
    }

    public void ReceiveNpcLife(TMP_InputField inputField)
    {
        inputNpcLife = int.Parse(inputField.text);
    }

    public void ReceiveNpcName(TMP_InputField inputField)
    {
        npcName = inputField.text;
    }

    public void Buttons(int number)
    {
        switch (number)
        {
            case 0:
                npcLife += inputNpcLife;
                UpdateNpcStats();
                break;
            case 1:
                npcLife = inputNpcLife;
                UpdateNpcStats();
                break;
            case 2:
                npcLife -= inputNpcLife;
                UpdateNpcStats();
                break;
            default:
                return;
        }
    }

    private void UpdateNpcStats()
    {
        npcSelected.UpdateStats(npcLife, npcName);
    }

    public void SetNull()
    {
        inputLife.text = "New life";
        inputName.text = "New name";
        npcLife = 0;
        npcName = "Name";
    }
}

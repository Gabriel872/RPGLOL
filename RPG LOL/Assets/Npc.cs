using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Npc : Character
{
    [SerializeField] private Canvas npcEditorCanvas;

    public TextMeshProUGUI labelName, labelLife;

    private void Start()
    {
        labelName.text = GetName();
        labelLife.text = GetStats().ToString();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        npcEditorCanvas.gameObject.SetActive(true);
        NpcEditor.instance.GetNpc(this);
    }

    public void UpdateStats(int life, string name)
    {
        SetLife(life);
        SetName(name);
        labelName.text = GetName();
        labelLife.text = GetStats().ToString();
    }
}

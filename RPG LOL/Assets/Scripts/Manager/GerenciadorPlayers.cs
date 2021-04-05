using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GerenciadorPlayers : MonoBehaviour
{
    public GameObject preFab;

    public void AddPlayer(GameObject button)
    {
        preFab.GetComponent<Gerenciador>().button = button;
        Instantiate(preFab, new Vector2(button.transform.position.x, button.transform.position.y), Quaternion.identity, button.transform.parent);
        button.SetActive(false);
    }
}

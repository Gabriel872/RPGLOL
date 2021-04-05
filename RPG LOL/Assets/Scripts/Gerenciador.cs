using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour
{
    TextMeshProUGUI nameFinal, vidaFinal;
    public GameObject button;
    public GameObject playerInstance;
    public Gerador ger;
    private MoveObject mo;

    private void Start()
    {
        ger.AddPlayerInScene();
        mo = playerInstance.GetComponent<MoveObject>();
    }

    public void AumentaVida(TextMeshProUGUI lifeText)
    {
        int a = int.Parse(lifeText.text);
        a++;
        mo.vida.text = a.ToString();
        lifeText.text = a.ToString();
    }

    public void ReduzVida(TextMeshProUGUI lifeText)
    {
        int a = int.Parse(lifeText.text);
        a--;
        mo.vida.text = a.ToString();
        lifeText.text = a.ToString();
    }

    public void GetVida(TextMeshProUGUI vida)
    {
        vidaFinal = vida;
    }
    public void MudaVida(TMP_InputField inputFieldLife)
    {
        if (inputFieldLife != null)
            vidaFinal.text = inputFieldLife.text;
    }

    public void GetName(TextMeshProUGUI name)
    {
        nameFinal = name;
    }

    public void Nome(TMP_InputField inputField)
    {
        nameFinal.text = inputField.text;
    }

    public void RemovePlayer()
    {
        button.SetActive(true);
        Destroy(playerInstance);
        Destroy(this.gameObject);
    }
}

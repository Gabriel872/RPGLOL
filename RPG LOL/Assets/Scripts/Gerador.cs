using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject prefabNPC;
    public GameObject prefabPlayer;
    public GameObject prefabPlayerUI;
    public GameObject cam;
    public GameObject parent;
    public GameObject parentUI;

    private GameManager GM;

    private Vector2 camPos;

    private void Start()
    {
        GM = GameManager.instance;
    }

    private void Update()
    {
        camPos = cam.transform.position;
        transform.position = camPos;

        if (GM.isPaused == false)
        {
            if (Input.GetKeyUp(KeyCode.C))
            {
                SpawnNPC();
            }

            if (Input.GetKeyUp(KeyCode.G))
            {
                AddPlayerInScene();
            }
        }
    }

    private void SpawnNPC()
    {
        Instantiate(prefabNPC, gameObject.transform.position, Quaternion.identity, parent.transform);
    }

    public void AddPlayerInScene()
    {
        if(GM.playerArray.Count <= 5)
        {
            GameObject prefab = Instantiate(prefabPlayer, gameObject.transform.position, Quaternion.identity, parent.transform);
            GM.AddPlayer(prefab.GetComponent<PlayerTest>(), prefabPlayerUI.GetComponent<StatusManager>());
            Instantiate(prefabPlayerUI, parentUI.transform);
        }
        else
        {
            Debug.Log("Cheio");
        }
    }
}

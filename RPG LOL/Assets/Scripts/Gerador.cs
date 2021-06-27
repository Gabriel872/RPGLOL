using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerador : MonoBehaviour
{
    public GameObject prefabAliado;
    public GameObject prefabPlayer;
    public GameObject cam;
    public GameObject parent;
    public GameManager GM;

    private Vector2 camPos;

    private void Update()
    {
        camPos = cam.transform.position;
        transform.position = camPos;

        if (GM.isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                SpawnBox();
            }
        }
    }

    private void SpawnBox()
    {
        Instantiate(prefabAliado, gameObject.transform.position, Quaternion.identity, parent.transform);
    }

    public void AddPlayerInScene()
    {
        Instantiate(prefabPlayer, gameObject.transform.position, Quaternion.identity, parent.transform);
    }
}

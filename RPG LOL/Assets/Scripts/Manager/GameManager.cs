using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject cursorChaser;
    public GameObject addObjects;

    public bool isPaused;
    public bool editMode;

    public string[] a = new string[3];
    public string layer;

    private int count = 0;

    [SerializeField] TextMeshProUGUI _actualLayer;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Screen.fullScreen = false;
        layer = a[0];

        DontDestroyOnLoad(instance);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !editMode)
        {
            cursorChaser.SetActive(true);
            addObjects.SetActive(true);
            editMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && editMode)
        {
            cursorChaser.SetActive(false);
            addObjects.SetActive(false);
            editMode = false;
        }

        if (isPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (count < a.Length - 1)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                layer = a[count];
                _actualLayer.text = ("Layer: " + layer);
            }
        }
    }

    public void PauseGame()
    {
        Debug.Log("Pause");
        instance.isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        instance.isPaused = false;
        Time.timeScale = 1f;
    }
}

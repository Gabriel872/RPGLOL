using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject cursorChaser;
    public GameObject addObjects;

    public bool isPaused;
    public bool editMode;

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
    }

    public void PauseGame()
    {
        Debug.Log("Pause");
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Debug.Log("Resume");
        isPaused = false;
        Time.timeScale = 1f;
    }
}

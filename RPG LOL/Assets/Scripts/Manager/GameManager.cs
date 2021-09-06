using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI _positionLayer;
    [SerializeField] TextMeshProUGUI _actualLayer;
    [SerializeField] private GameObject _controlPanel;

    [Space(20)]

    public List<PlayerTest> playerArray = new List<PlayerTest>();
    public List<StatusManager> playerUIArray = new List<StatusManager>();

    [Space(20)]

    public GameObject cursorChaser;
    public GameObject addObjects;

    [Space(20)]

    public bool isPaused;
    public bool editMode;

    [Space(20)]

    public string[] a = new string[2];
    public string layer;

    [Space(10)]

    private int count = 0;
    public int sortingLayer = 0;

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

        layer = a[0];
        _actualLayer.text = ("Layer: " + layer);
        _positionLayer.text = ("Posição: " + sortingLayer);

        DontDestroyOnLoad(instance);
    }

    private void Update()
    {
        #region EditorMode
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
        #endregion

        #region Camada e ordem
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

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                sortingLayer++;
                _positionLayer.text = ("Posição: " + sortingLayer);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                sortingLayer--;
                _positionLayer.text = ("Posição: " + sortingLayer);
            }
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (instance.isPaused)
            {
                Resume();
                _controlPanel.SetActive(false);
            }
            else
            {
                PauseGame();
                _controlPanel.SetActive(true);
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

    public void quitApp()
    {
        Application.Quit();
    }

    public void AddPlayer(PlayerTest player, StatusManager playerUI)
    {
        if (playerArray.Count <= 5)
        {
            playerArray.Add(player);
            playerUIArray.Add(playerUI);
        }

        if (playerArray.Count <= 6)
        {
            for (int i = 0; i < playerArray.Count; i++)
            {
                playerArray[i].id = i;
                playerUIArray[i].id = i;
            }
        }
    }
}

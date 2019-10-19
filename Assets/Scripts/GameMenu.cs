using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject UI_PausePanel;
    [SerializeField] private GameObject UI_LosePanel;
    [SerializeField] private GameObject UI_WinPanel;
    public static bool isPaused;
    [SerializeField] private SceneFader sceneFader;


    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(BuildMap.isGameOver)
        {
            UI_LosePanel.SetActive(true);
            return;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            UI_PausePanel.SetActive(!UI_PausePanel.activeSelf);
        }
    }

    public void Restart()
    {
        isPaused = false;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        isPaused = false;
        UI_PausePanel.SetActive(false);
    }

    public void MainMenu()
    {
        sceneFader.FadeTo("MainMenu");
    }

    public void Win()
    {
        BuildMap.isGameOver = true;
        UI_WinPanel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField] private SceneFader sceneFader;
    public void Beginer()
    {
        GameOptions.Height = 9;
        GameOptions.Width = 9;
        GameOptions.MinesCount = 10;
        LoadGame();
    }

    public void Intermediate()
    {
        GameOptions.Height = 16;
        GameOptions.Width = 16;
        GameOptions.MinesCount = 40;
        LoadGame();
    }

    public void Expert()
    {
        GameOptions.Height = 16;
        GameOptions.Width = 30;
        GameOptions.MinesCount = 99;
        LoadGame();
    }

    public void LoadGame()
    {
        sceneFader.FadeTo("LevelScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

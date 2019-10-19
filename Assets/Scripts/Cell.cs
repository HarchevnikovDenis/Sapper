using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text minesText;              //Текст для отображения кол-ва мин вокруг ячейки
    public Color hoverColor;
    private Color standartColor;
    public Color openColor;
    public bool isMarked = false;       //Помечена ли ячейка флагом

    [SerializeField] private Image flagImg;
    [SerializeField] private Image bombImage;

    [SerializeField] private Color color0;
    [SerializeField] private Color color1;
    [SerializeField] private Color color2;
    [SerializeField] private Color color3;
    [SerializeField] private Color color4;
    [SerializeField] private Color color5;
    [SerializeField] private Color color6;
    [SerializeField] private Color color7;
    [SerializeField] private Color color8;

    public int i;       //Индексы ячейки
    public int j;

    private void Start()
    {
        standartColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseOver()
    {
        if (BuildMap.isOpen[i, j] || GameMenu.isPaused || BuildMap.isGameOver)
            return;

        gameObject.GetComponent<MeshRenderer>().material.color = hoverColor;

        if(Input.GetMouseButtonDown(1))     //Нажатие правой кнопки мыши(установка флага/снятие его)
        {
            if (BuildMap.isGameOver || BuildMap.flagsCount <= 0)
                return;
            if(!flagImg.gameObject.activeSelf)
            {
                flagImg.gameObject.SetActive(true);
                BuildMap.openedCell++;
                isMarked = true;
                BuildMap.flagsCount--;
            }
            else
            {
                flagImg.gameObject.SetActive(false);
                BuildMap.openedCell--;
                isMarked = false;
                BuildMap.flagsCount++;
            }
            Timer timer = FindObjectOfType<Timer>();
            if (timer != null)
                timer.RefreshCountFlagsCount();
        }
    }

    private void OnMouseExit()
    {
        if (!BuildMap.isOpen[i, j])
            gameObject.GetComponent<MeshRenderer>().material.color = standartColor;
    }

    private void OnMouseDown()
    {
        if (isMarked || BuildMap.isGameOver || GameMenu.isPaused)
            return;

        if (!BuildMap.isOpen[i, j])
        {
            BuildMap.isOpen[i, j] = true;

            BuildMap map = FindObjectOfType<BuildMap>();
            if (!BuildMap.isFirstStepDone)
            {
                BuildMap.isFirstStepDone = true;
                if (map)
                {
                    map.FirstStep();
                }
            }
            map.OpenNewCell(i, j);

            ColorText(i, j);
            
            if (BuildMap.field[i, j] != "*")
            {
                gameObject.GetComponent<MeshRenderer>().material.color = openColor;
            }

            if(BuildMap.flagsCount+BuildMap.openedCell == BuildMap.needCell)
            {
                GameMenu gameMenu = FindObjectOfType<GameMenu>();
                gameMenu.Win();
            }
        }
    }

    public void ColorText(int i, int j)
    {
        switch (BuildMap.field[i, j])
        {
            case "0":
                minesText.color = color0;
                break;
            case "1":
                minesText.color = color1;
                break;
            case "2":
                minesText.color = color2;
                break;
            case "3":
                minesText.color = color3;
                break;
            case "4":
                minesText.color = color4;
                break;
            case "5":
                minesText.color = color5;
                break;
            case "6":
                minesText.color = color6;
                break;
            case "7":
                minesText.color = color7;
                break;
            case "8":
                minesText.color = color8;
                break;
        }
    }

    public void OpenBomp()
    {
        bombImage.gameObject.SetActive(true);
    }
}

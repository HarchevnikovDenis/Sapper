using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public Text minesText;
    public Color hoverColor;
    private Color standartColor;
    public Color openColor;

    [SerializeField] private Color color0;
    [SerializeField] private Color color1;
    [SerializeField] private Color color2;
    [SerializeField] private Color color3;
    [SerializeField] private Color color4;
    [SerializeField] private Color color5;
    [SerializeField] private Color color6;
    [SerializeField] private Color color7;
    [SerializeField] private Color color8;

    public int i;
    public int j;

    private void Start()
    {
        standartColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseOver()
    {
        if(!BuildMap.isOpen[i, j])
            gameObject.GetComponent<MeshRenderer>().material.color = hoverColor;

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Flag");
        }
    }

    private void OnMouseExit()
    {
        if (!BuildMap.isOpen[i, j])
            gameObject.GetComponent<MeshRenderer>().material.color = standartColor;
    }

    private void OnMouseDown()
    {
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
            
            gameObject.GetComponent<MeshRenderer>().material.color = openColor;
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
}

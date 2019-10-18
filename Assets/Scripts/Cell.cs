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

    public int i;
    public int j;

    private void Start()
    {
        standartColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseEnter()
    {
        if(!BuildMap.isOpen[i, j])
            gameObject.GetComponent<MeshRenderer>().material.color = hoverColor;
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

            gameObject.GetComponent<MeshRenderer>().material.color = openColor;
        }
    }
}

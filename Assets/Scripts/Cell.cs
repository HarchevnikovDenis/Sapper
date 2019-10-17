using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Color hoverColor;
    private Color standartColor;

    private void Start()
    {
        standartColor = gameObject.GetComponent<MeshRenderer>().material.color;
    }

    private void OnMouseEnter()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = standartColor;
    }
}

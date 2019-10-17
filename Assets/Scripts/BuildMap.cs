using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMap : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    private Vector3 startSpawnPosition;

    private void Awake()
    {
        GameOptions.Width = 30;
        GameOptions.Height = 16;
        GameOptions.MinesCount = 99;
        startSpawnPosition = Vector3.zero;

        BuildField(GameOptions.Height, GameOptions.Width);
    }

    private void BuildField(int height, int width)
    {
        char[,] field = new char[height, width];

        Debug.Log(GameOptions.MinesCount.ToString());
        field = RandomBoom(height, width);

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Vector3 offset = new Vector3(1.6f * j, 0, -1.6f * i);
                GameObject cell = Instantiate(cellPrefab, startSpawnPosition + offset, Quaternion.identity);
                if (field[i, j] == '*')
                    cell.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }

    private char[,] RandomBoom(int height, int width)
    {
        char[,] field = new char[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                field[i, j] = ' ';
            }
        }
        int mines = 0;

        while (mines < GameOptions.MinesCount)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    float chance = Random.Range(0.0f, 1.0f);
                    if (chance >= 0.95f)
                    {
                        field[i, j] = '*';
                        mines++;

                        if (mines == GameOptions.MinesCount)
                        {
                            Debug.Log(mines.ToString());
                            return field;
                        }
                    }
                }
            }
        }
        return field;
    }
}

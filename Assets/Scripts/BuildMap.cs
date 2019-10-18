using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMap : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    private Vector3 startSpawnPosition;
    private int count = 0;
    public static bool[,] isOpen;
    private GameObject[,] cells;
    private int height;
    private int width;
    public static bool isFirstStepDone;
    private string[,] field = null;

    private void Awake()
    {
        GameOptions.Width = 30;
        GameOptions.Height = 16;
        GameOptions.MinesCount = 99;
        startSpawnPosition = Vector3.zero;

        height = GameOptions.Height;
        width = GameOptions.Width;

        isOpen = new bool[height, width];
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                isOpen[i, j] = false;
            }
        }

        field = new string[height, width]; for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                field[i, j] = string.Empty;
            }
        }
        cells = new GameObject[height, width];

        BuildField();
    }

    public void FirstStep()
    {
        field = RandomBoom();
        field = MinesCounter();
    }

    private void BuildField()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 offset = new Vector3(1.55f * j, 0, -1.55f * i);
                cells[i, j] = Instantiate(cellPrefab, startSpawnPosition + offset, Quaternion.identity);

                /*if (field[i, j] == "*")
                    cells[i ,j].GetComponent<MeshRenderer>().material.color = Color.red;*/
                //cells[i, j].GetComponent<Cell>().minesText.text = field[i, j].ToString();

                cells[i, j].GetComponent<Cell>().i = i;
                cells[i, j].GetComponent<Cell>().j = j;
            }
        }
    }

    private string[,] RandomBoom()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                field[i, j] = "";
            }
        }
        int mines = 0;

        while (mines < GameOptions.MinesCount)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (isOpen[i, j])
                        continue;
                    float chance = Random.Range(0.0f, 1.0f);
                    if (chance >= 0.9f)
                    {
                        field[i, j] = "*";
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

    private string[,] MinesCounter()
    {
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] != "*")
                {
                    count = 0;
                    CountMines(i - 1, j - 1, field);
                    CountMines(i - 1, j, field);
                    CountMines(i - 1, j + 1, field);
                    CountMines(i, j - 1, field);
                    CountMines(i, j + 1, field);
                    CountMines(i + 1, j - 1, field);
                    CountMines(i + 1, j, field);
                    CountMines(i + 1, j + 1, field);
                    field[i, j] = count.ToString();
                }
                /*cells[i, j].GetComponent<Cell>().minesText.text = field[i, j].ToString();
                if (field[i, j] == "*")
                    cells[i, j].GetComponent<MeshRenderer>().material.color = Color.red;*/
            }
        }
        return field;
    }

    private void CountMines(int i, int j, string[,] field)
    {
        try
        {
            if (field[i, j] == "*")
                count++;
            else
                return;
        }
        catch (System.IndexOutOfRangeException)
        {
            return;
        }
        
    }

    public void OpenNewCell(int i, int j)
    {
        cells[i, j].GetComponent<Cell>().minesText.text = field[i, j].ToString();
    }
}

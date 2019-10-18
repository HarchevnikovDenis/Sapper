using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameOptions
{
    private static int width;       
    private static int height;
    private static int minesCount;  //  minesCount == falgsCount


    public static int Width
    {
        get
        {
            return width;
        }

        set
        {
            if (value < 9)
                width = 9;
            else
                width = value;
        }
    }
    public static int Height
    {
        get
        {
            return height;
        }

        set
        {
            if (value < 9)
                height = 9;
            else
                height = value;
        }
    }

    public static int MinesCount
    {
        get
        {
            return minesCount;
        }

        set
        {
            if (value < 1)
                minesCount = 1;
            else
                minesCount = value;

        }
    }
}

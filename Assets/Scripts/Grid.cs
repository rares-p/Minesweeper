using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    static int[] cx = new int[265];
    static int[] cy = new int[265];
    public static int n = 15, ic, sc;
    public static Box[,] elements = new Box[n, n];

    public static int[] dl = { -1, -1, 0, 1, 1, 1, 0, -1 };
    public static int[] dc = { 0, 1, 1, 1, 0, -1, -1, -1 };
    public static bool[,] visited = new bool[n, n];
    public static bool lost, won, first;
    public static int mines = 35, flags = mines;
    public static int uncovered;

    public static void uncoverMines(int val = 11)
    {
        foreach (Box x in elements)
            if (x.mine)
                x.loadTexture(val);
            else if (x.GetComponent<SpriteRenderer>().sprite.name == "flag")
                x.loadTexture(13);
    }

    public static void fill(Box elem)
    {
        int x = (int)elem.transform.position.x + 7;
        int y = (int)elem.transform.position.y + 7;
        ic = sc = 0;
        cx[0] = x;
        cy[0] = y;
        visited[x, y] = true;
        while (ic <= sc)
        {
            x = cx[ic];
            y = cy[ic++];
            int value = countMines(x, y);
            elements[x, y].loadTexture(value);
            elements[x, y].covered = true;
            if (value == 0)
            {
                for (int i = 0; i < 8; i++)
                    if (x + dl[i] >= 0 && x + dl[i] < n && y + dc[i] >= 0 && y + dc[i] < n && !visited[x + dl[i], y + dc[i]])
                    {
                        visited[x + dl[i], y + dc[i]] = true;
                        sc++;
                        cx[sc] = x + dl[i];
                        cy[sc] = y + dc[i];
                    }
            }
        }
        Grid.uncovered += sc;
    }

    public static int countMines(int x, int y)
    {
        int mines = 0;
        for (int i = 0; i < 8; i++)
            if (x + dl[i] >= 0 && x + dl[i] < n && y + dc[i] >= 0 && y + dc[i] < n && elements[x + dl[i], y + dc[i]].mine)
                mines++;

        return mines;
    }

    public static void setMines(int numberOfMines = 35)
    {
        for (int i = 0; i < numberOfMines;)
        {
            int x = Random.Range(0, n);
            int y = Random.Range(0, n);
            if (!elements[x, y].mine)
            {
                elements[x, y].mine = true;
                i++;
            }
        }
    }
}

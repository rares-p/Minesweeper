using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Sprite[] sprites;
    public bool mine, covered;
    public int x, y;

    void Awake()
    {
        x = (int)transform.position.x + 7;
        y = (int)transform.position.y + 7;
        Grid.elements[x, y] = this;
    }
    
    /*private void Start()
    {
        Grid.uncoverMines();
    }*/

    void Update()
    {
        
    }

    public void loadTexture(int index)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }

    private void OnMouseUp()
    {
        if (!(Grid.lost || Grid.won))
        {
            if (!Grid.first)
            {
                if (mine)
                {
                    int x = Random.Range(0, Grid.n);
                    int y = Random.Range(0, Grid.n);
                    while (Grid.elements[x, y].mine)
                    {
                        x = Random.Range(0, Grid.n);
                        y = Random.Range(0, Grid.n);
                    }
                    Grid.elements[x, y].mine = true;
                    mine = false;
                }
                Grid.first = true;
            }
            if (mine)
            {
                Grid.lost = true;
                Grid.uncoverMines();
                loadTexture(12);
            }
            else
            {
                if (!covered)
                    Grid.uncovered++;
                Grid.visited[x, y] = true;
                int value = Grid.countMines(x, y);
                if (value == 0)
                    Grid.fill(this);
                else
                    loadTexture(value);
                if (Grid.uncovered + Grid.mines == 225)
                {
                    Grid.won = true;
                    Grid.uncoverMines(9);
                }
            }
            covered = true;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && !covered && !(Grid.lost || Grid.won))
        {
            string name = GetComponent<SpriteRenderer>().sprite.name;
            if (name == "flag")
            {
                loadTexture(10);
                Grid.flags++;
            }
            else if (name == "hmm")
                loadTexture(14);
            else
            {
                loadTexture(9);
                Grid.flags--;
            }
        }
    }
}

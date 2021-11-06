using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMines : MonoBehaviour
{
    bool okfrt;
    public GameObject timer;

    void Start()
    {
        Grid.setMines(Grid.mines);
    }

    void Update()
    {
        if (Grid.first && !okfrt)
        {
            timer.GetComponent<Count>().enabled = true;
            okfrt = true;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FaceSwap : MonoBehaviour
{
    public Sprite[] faces;

    void Start()
    {
        this.GetComponent<Image>().sprite = faces[0];
    }
    
    void Update()
    {
        if (Grid.lost)
            this.GetComponent<Image>().sprite = faces[3];
        else if (Grid.won)
            this.GetComponent<Image>().sprite = faces[2];
        else
        {
            if (Input.GetMouseButtonDown(0))
                this.GetComponent<Image>().sprite = faces[1];
            if (Input.GetMouseButtonUp(0))
                this.GetComponent<Image>().sprite = faces[0];
        }
    }

    public void restart()
    {
        Grid.lost = false;
        Grid.won = false;
        Grid.uncovered = 0;
        Grid.flags = Grid.mines;
        Grid.first = false;
        for (int i = 0; i < 15; i++)
            for (int j = 0; j < 15; j++)
                Grid.visited[i, j] = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

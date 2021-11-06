using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    float time;

    void Start()
    {
        time = Time.time;
    }
    void Update()
    {
        if (!(Grid.won || Grid.lost))
            this.GetComponent<Text>().text = ((int)(Time.time - time)).ToString();
    }
}

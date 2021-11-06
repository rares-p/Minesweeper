using UnityEngine;
using UnityEngine.UI;

public class Flags : MonoBehaviour
{
    void Update()
    {
        this.GetComponent<Text>().text = Grid.flags.ToString();
    }
}

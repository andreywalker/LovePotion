using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Slider>().onValueChanged.AddListener(
            v => Debug.Log("Slider value: " + v)
        );
    }
}
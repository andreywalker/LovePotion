using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        slider.value = MusicManager.instance.GetVolume();
        slider.onValueChanged.AddListener(MusicManager.instance.SetVolume);
    }
}
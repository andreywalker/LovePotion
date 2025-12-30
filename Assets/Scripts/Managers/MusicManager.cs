using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
	private AudioSource audioSource;
    private const string VolumeKey = "MusicVolume";

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();

        // Load saved volume (default = 0.5)
        float savedVolume = PlayerPrefs.GetFloat(VolumeKey, 0.5f);
        audioSource.volume = savedVolume;
    }
    
    public void SetVolume(float value)
    {
        audioSource.volume = value;
        PlayerPrefs.SetFloat(VolumeKey, value);
        PlayerPrefs.Save(); // ensure persistence
    }

    public float GetVolume()
    {
        return audioSource.volume;
    }
    
}

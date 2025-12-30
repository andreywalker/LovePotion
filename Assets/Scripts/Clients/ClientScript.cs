using UnityEngine;

public class ClientScripr : MonoBehaviour
{
	private const string key = "ClientID";
	
	void Awake()
        int clientID = PlayerPrefs.GetInt(key, 0);
        ClientData c = GetClient(clientID);
        Sprite sprite = Resources.Load<Sprite>("Sprites/Clients/Client"+clientID);
		if (sprite == null)
		{
			Sprite sprite = Resources.Load<Sprite>("Sprites/Clients/Client0");
		}
		GetComponent<Image>().sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

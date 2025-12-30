using UnityEngine;

[CreateAssetMenu(menuName = "Game/Client")]
public class ClientData : ScriptableObject
{
	public int ID;
    public string clientName;
    public string requestText;

    public float desiredLove;          
    public float desiredStability;     
    public float chaosTolerance;       

    public float perfectThreshold = 80f;
    public float goodThreshold = 50f;
    public float weirdThreshold = 25f;

    [TextArea] public string perfectReaction;
    [TextArea] public string goodReaction;
    [TextArea] public string weirdReaction;
    [TextArea] public string disasterReaction;
}


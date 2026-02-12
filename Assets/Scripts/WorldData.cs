using UnityEngine;

[CreateAssetMenu(menuName = "Game/World Data")]
public class WorldData : ScriptableObject
{
    public int worldId;
    public string worldName;
    public int starsRequired;
}

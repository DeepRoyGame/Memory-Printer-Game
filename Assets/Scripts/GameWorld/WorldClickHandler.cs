using UnityEngine;

public class WorldClickHandler : MonoBehaviour
{
    public static WorldClickHandler Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void OnWorldSelected(int worldId)
    {
        GameManagerCycle.Instance.OpenWorldLevels(worldId - 1);
    }
}

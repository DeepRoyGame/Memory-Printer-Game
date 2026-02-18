using UnityEngine;
using System.Collections.Generic;

public class WorldDatabase : MonoBehaviour
{
    public static WorldDatabase Instance;

    [Header("All Worlds")]
    public List<WorldData> worlds;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public List<WorldData> GetWorlds()
    {
        return worlds;
    }
}

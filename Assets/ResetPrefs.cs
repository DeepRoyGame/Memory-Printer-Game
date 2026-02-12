using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PLAYER PREFS RESET");
    }
}

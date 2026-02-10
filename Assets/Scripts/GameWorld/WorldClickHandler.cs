using UnityEngine;

public class WorldClickHandler : MonoBehaviour
{
    public GameObject worldPanel;
    public GameObject worldLevelPanel;

    //public int worldIndex;

    public void OpenWorld()
    {
        worldPanel.SetActive(false);
        worldLevelPanel.SetActive(true);

        //Debug.Log("Opened World: " + worldIndex);
    }
    public void CloseWorld()
    {
        worldPanel.SetActive(true);
        worldLevelPanel.SetActive(false);

        //Debug.Log("Closed World: " + worldIndex);
    }
}

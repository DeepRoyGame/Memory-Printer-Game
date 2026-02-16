using UnityEngine;

public class HUDVisibilityController : MonoBehaviour
{
    [Header("HUD Elements")]
    public GameObject batteryBar;
    public GameObject coinPanel;

    public enum UIState
    {
        Menu,
        World,
        Level,
        Gameplay,
        Pause,
        Revive,
        GameOver,
        LevelComplete
    }
    public void UpdateHUD(UIState state)
    {
        bool showBattery =
            state == UIState.Revive ||
            state == UIState.GameOver ||
            state == UIState.World ||
            state == UIState.Level;

        batteryBar.SetActive(showBattery);

        bool showCoins =
            state == UIState.Menu ||
            state == UIState.Level ||
            state == UIState.Revive;

        coinPanel.SetActive(showCoins);
    }

}

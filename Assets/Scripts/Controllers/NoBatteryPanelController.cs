using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NoBatteryPanelController : MonoBehaviour
{
    [Header("Buttons")]
    public Button closeButton;
    public Button buyBatteryButton;
    public Button watchAdButton;

    [Header("UI")]
    public TextMeshProUGUI timerText;

    [Header("Config")]
    public int batteryCost = 100;

    void OnEnable()
    {
        Debug.Log("NoBatteryPanel ENABLED");

        // SAFETY: reset time
        Time.timeScale = 1f;

        closeButton.onClick.RemoveAllListeners();
        buyBatteryButton.onClick.RemoveAllListeners();
        watchAdButton.onClick.RemoveAllListeners();

        closeButton.onClick.AddListener(OnCloseClicked);
        buyBatteryButton.onClick.AddListener(OnBuyBatteryClicked);
        watchAdButton.onClick.AddListener(OnWatchAdClicked);
        UpdateButtonStates();
    }

        void Update()
    {
        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        float seconds = BatteryManager.Instance.GetSecondsUntilNextBattery();

        int minutes = Mathf.FloorToInt(seconds / 60f);
        int secs = Mathf.FloorToInt(seconds % 60f);

        timerText.text = $"{minutes:00}:{secs:00}";
    }

    //void OnBuyBatteryClicked()
    //{
    //    if (GameEconomyManager.Instance.GetCoins() < batteryCost)
    //        return;

    //    GameEconomyManager.Instance.SpendCoins(batteryCost);
    //    BatteryManager.Instance.AddBatteryInstant(1);

    //    gameObject.SetActive(false);   // 🔥 force close
    //    GameManagerCycle.Instance.ShowMenu();
    //}

    //void OnWatchAdClicked()
    //{
    //    // Simulated rewarded ad success
    //    BatteryManager.Instance.AddBatteryInstant(1);

    //    gameObject.SetActive(false);
    //    GameManagerCycle.Instance.ShowMenu();
    //}

    //void OnCloseClicked()
    //{
    //    gameObject.SetActive(false);   // 🔥 force close
    //    GameManagerCycle.Instance.ShowMenu();
    //}
    void OnBuyBatteryClicked()
    {
        if (GameEconomyManager.Instance.GetCoins() < batteryCost)
            return;

        GameEconomyManager.Instance.SpendCoins(batteryCost);
        BatteryManager.Instance.AddBatteryInstant(1);

        GameManagerCycle.Instance.ShowMenu();
        GameManagerCycle.Instance.hud.UpdateHUD(
            HUDVisibilityController.UIState.Menu
        );
    }

    void OnWatchAdClicked()
    {
        BatteryManager.Instance.AddBatteryInstant(1);

        GameManagerCycle.Instance.ShowMenu();
        GameManagerCycle.Instance.hud.UpdateHUD(
            HUDVisibilityController.UIState.Menu
        );
    }

    void OnCloseClicked()
    {
        GameManagerCycle.Instance.ShowMenu();
        GameManagerCycle.Instance.hud.UpdateHUD(
            HUDVisibilityController.UIState.Menu
        );
    }

    void UpdateButtonStates()
    {
        int coins = GameEconomyManager.Instance.GetCoins();

        buyBatteryButton.interactable = coins >= batteryCost;

        // Ads are ALWAYS allowed
        watchAdButton.interactable = true;
    }
}

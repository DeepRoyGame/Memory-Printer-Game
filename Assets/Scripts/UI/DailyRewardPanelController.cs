using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DailyRewardPanelController : MonoBehaviour
{
    [Header("Day Items")]
    public GameObject[] dayItems; // Size = 7

    [Header("Texts")]
    public TextMeshProUGUI todayRewardText;

    [Header("Buttons")]
    public Button collectButton;
    public Button watchAdButton;
    public Button closeButton;

    void OnEnable()
    {
        RefreshUI();

        collectButton.onClick.RemoveAllListeners();
        watchAdButton.onClick.RemoveAllListeners();
        closeButton.onClick.RemoveAllListeners();

        collectButton.onClick.AddListener(OnCollectClicked);
        watchAdButton.onClick.AddListener(OnWatchAdClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
    }

    void RefreshUI()
    {
        int today = DailyRewardManager.Instance.GetCurrentDay();

        for (int i = 0; i < dayItems.Length; i++)
        {
            Transform claimedCheck = dayItems[i].transform.Find("ClaimedCheck");

            // Show check for past days
            if (claimedCheck != null)
                claimedCheck.gameObject.SetActive(i + 1 < today);

            // Highlight current day (optional glow effect)
            Image bg = dayItems[i].GetComponent<Image>();
            if (bg != null)
            {
                if (i + 1 == today)
                    bg.color = new Color(0f, 1f, 0.6f, 1f);   // neon highlight
                else
                    bg.color = Color.white;
            }
        }

        todayRewardText.text = GetRewardText(today);
    }

    string GetRewardText(int day)
    {
        switch (day)
        {
            case 1: return "TODAY'S REWARD: 50 COINS";
            case 2: return "TODAY'S REWARD: 1 BATTERY";
            case 3: return "TODAY'S REWARD: 75 COINS";
            case 4: return "TODAY'S REWARD: FREEZE POWER";
            case 5: return "TODAY'S REWARD: 2 BATTERIES";
            case 6: return "TODAY'S REWARD: 100 COINS";
            case 7: return "TODAY'S REWARD: 200 COINS";
            default: return "";
        }
    }

    void OnCollectClicked()
    {
        DailyRewardManager.Instance.ClaimReward();
        ClosePanel();
    }

    void OnWatchAdClicked()
    {
        // Simulate ad success
        DailyRewardManager.Instance.ClaimReward();
        DailyRewardManager.Instance.ClaimReward(); // double reward
        ClosePanel();
    }

    void OnCloseClicked()
    {
        ClosePanel();
    }

    void ClosePanel()
    {
        gameObject.SetActive(false);
        GameManagerCycle.Instance.ShowMenu();
    }
}
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorldScrollController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public int totalPages = 5;
    public float scrollSpeed = 10f;

    private int currentPage = 0;
    private bool isScrolling = false;

    IEnumerator Start()
    {
        // Wait one frame so layout calculates properly
        yield return null;

        currentPage = 0;
        scrollRect.horizontalNormalizedPosition = 0f;
    }

    public void NextPage()
    {
        if (isScrolling) return;

        if (currentPage < totalPages - 1)
        {
            currentPage++;
            StartCoroutine(SmoothScrollToPage());
        }
    }

    public void PrevPage()
    {
        if (isScrolling) return;

        if (currentPage > 0)
        {
            currentPage--;
            StartCoroutine(SmoothScrollToPage());
        }
    }

    IEnumerator SmoothScrollToPage()
    {
        isScrolling = true;

        float targetPosition = (float)currentPage / (totalPages - 1);

        while (Mathf.Abs(scrollRect.horizontalNormalizedPosition - targetPosition) > 0.001f)
        {
            scrollRect.horizontalNormalizedPosition =
                Mathf.Lerp(scrollRect.horizontalNormalizedPosition,
                           targetPosition,
                           Time.deltaTime * scrollSpeed);

            yield return null;
        }

        scrollRect.horizontalNormalizedPosition = targetPosition;
        isScrolling = false;
    }
}

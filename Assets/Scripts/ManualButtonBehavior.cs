using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManualButtonBehavior : MonoBehaviour
{
    //[SerializeField] Button previousButton;
    //[SerializeField] Button nextButton;

    [SerializeField] GameObject[] pages;

    public void NextPage()
    {
        int currentIndex = GetActivePageIndex();
        int prevIndex = currentIndex - 1;
        if (prevIndex < 0 ) prevIndex = pages.Length - 1;
        pages[currentIndex].SetActive(false);
        pages[prevIndex].SetActive(true);
    }

    public void PreviousPage()
    {
        int currentIndex = GetActivePageIndex();
        int nextIndex = currentIndex + 1;
        if (nextIndex > pages.Length - 1) nextIndex = 0;
        pages[currentIndex].SetActive(false);
        pages[nextIndex].SetActive(true);
    }

    int GetActivePageIndex()
    {
        foreach (GameObject page in pages)
        {
            if (page.activeSelf)
            {
                return System.Array.IndexOf(pages, page);
            }
        }
        return 0;
    }
}

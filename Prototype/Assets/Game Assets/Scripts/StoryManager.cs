using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public GameObject[] storyPanel;
    public int currentStoryID = 0;

    void Start()
    {
        UpdateStoryPanel(0);
    }

    void Update()
    {
        
    }
    private void UpdateStoryPanel(int addedValue)
    {
        currentStoryID += addedValue;
        if (currentStoryID < 0)
            currentStoryID = 0;
        else if (currentStoryID >= storyPanel.Length)
            currentStoryID = storyPanel.Length - 1;

        for (int i = 0; i < storyPanel.Length; i++)
        {
            if(currentStoryID == i)
            {
                storyPanel[i].SetActive(true);
            }
            else
            {
                storyPanel[i].SetActive(false);
            }
        }
    }

    public void GoToNextStory()
    {
        UpdateStoryPanel(1);
    }

    public void BackToPreviousStory()
    {
        UpdateStoryPanel(-1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuickSceneManager : MonoBehaviour
{
    //public int cek ;
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextGame()
    {
        int temp = PlayerPrefs.GetInt("SelectedLevel") + 1 ;
        SceneManager.LoadScene("GameplayLevel" + temp.ToString());
        PlayerPrefs.SetInt("SelectedLevel", temp);
    }

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToLevelSelectOrStory()
    {
        if (PlayerPrefs.GetString("InitiateStory") != "opened")
        {
            SceneManager.LoadScene("StoryScene");
            PlayerPrefs.SetString("InitiateStory", "opened");
        }
        else
        {
            SceneManager.LoadScene("LevelSelect");
        }
    }
}

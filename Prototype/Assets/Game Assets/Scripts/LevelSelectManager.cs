using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] Sprite[] levelButtonSprites;
    [System.Serializable]
    public class LevelData {
        public Image[] imageStars;
        public int currentStars;
        public int currentButton;
        public Image levelButton;
    }
    public LevelData[] levelData;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("LevelLockStatus0", "unlocked");
        for (int i = 0; i < levelData.Length; i++)
        {
            if (PlayerPrefs.GetString("LevelLockStatus" + i) == "unlocked")
            {
                //TEMPORARY
                //levelData[i].levelButton.color = new Color(0.6320754f, 0.6055716f, 0.0506853f);
                levelData[i].levelButton.gameObject.GetComponent<Button>().interactable = true;
                levelData[i].levelButton.sprite = levelButtonSprites[1];
            }
            else
            {
                levelData[i].levelButton.sprite = levelButtonSprites[0];
                levelData[i].levelButton.gameObject.GetComponent<Button>().interactable = false;
            }

            //Debug.Log(PlayerPrefs.GetInt("Level" + i + "Stars"));
            //levelData[i].currentStars = PlayerPrefs.GetInt("Level"+i+"Stars");

            levelData[i].currentStars = PlayerPrefs.GetInt("LevelStarResult" + i);
            for (int j = 0; j < levelData[i].currentStars; j++)
            {
                if (j < levelData[i].imageStars.Length)
                {
                    levelData[i].imageStars[j].color = new Color(1f, 0.9813728f, 0, 1f);
                }
            }
            for (int j = levelData[i].currentStars; j < levelData[i].imageStars.Length; j++)
            {
                levelData[i].imageStars[j].color = new Color(0, 0, 0, 0.5f);
            }
        }
    }
    public void ButtonLevelClicked(int id)
    {
        Time.timeScale = 1f;
        /*if (id == 0)
        {
            //load story 1
            PlayerPrefs.SetInt("LoadPanelStory", id);
            SceneManager.LoadScene("SceneStory");
        }
        else
        { 
            SceneManager.LoadScene("GameplayLevel" + id.ToString());
        }*/
        PlayerPrefs.SetInt("SelectedLevel",id);
        Debug.Log("Level " + id + " Clicked");
    }
}

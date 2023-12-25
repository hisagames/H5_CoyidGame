using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataEnsiklopedia : MonoBehaviour
{
    //[SerializeField] int totalUnlockedLevel;

    public Text textTitle;
    public Text textsEnsiklopedia;
    public Image imgEnsiklopedia;

    public Image[] dataImageButton;
    public GameObject[] button;

    [System.Serializable]
    public class DataUpdateEnsiklopedia
    {
        public Sprite sprites;
        public string textTitle;
        public string teksEnsik;
    }

    public DataUpdateEnsiklopedia[] loadDataEnsiklopedia;
    public DataUpdateEnsiklopedia dataEnsiklopedia;

    private void Start()
    {
        InitiateLoad();
    }
    private void Update()
    {
        //LoadTeks();
        //LoadBankText();
    }
    
    public void InitiateLoad()
    {
        for(int i = 0; i <= dataImageButton.Length; i++)
        {
            //imgEnsiklopedia.color = new Color(1, 1, 1, 1);
            //textsEnsiklopedia.GetComponent<Text>().color = new Color(0, 0, 0, 1);

            int temp = PlayerPrefs.GetInt("LevelStarResult" + i);

            //if (i < totalUnlockedLevel)
            if (temp > 0)
            {
                dataImageButton[i].sprite = loadDataEnsiklopedia[i].sprites;
            }
        }
        LoadButton(0);
    }

    public void LoadButton(int selectedId)
    {
        for (int i = 0; i < dataImageButton.Length; i++)
        {
            if (i == selectedId)
                dataImageButton[i].GetComponentInParent<Image>().color = Color.yellow;
            else
                dataImageButton[i].GetComponentInParent<Image>().color = Color.white;
        }

        int temp = PlayerPrefs.GetInt("LevelStarResult" + selectedId);
        if (temp > 0)
        {
            textTitle.GetComponent<Text>().text = loadDataEnsiklopedia[selectedId].textTitle;
            textsEnsiklopedia.GetComponent<Text>().text = loadDataEnsiklopedia[selectedId].teksEnsik;

            imgEnsiklopedia.color = new Color(1, 1, 1, 1);
            imgEnsiklopedia.sprite = loadDataEnsiklopedia[selectedId].sprites;
        }
        else
        {
            textTitle.GetComponent<Text>().text = "Locked";
            textsEnsiklopedia.GetComponent<Text>().text = "-";

            imgEnsiklopedia.color = new Color(0, 0, 0, 0);
            imgEnsiklopedia.sprite = loadDataEnsiklopedia[selectedId].sprites;
        }
    }
}

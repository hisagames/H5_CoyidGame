using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashscreenManager : MonoBehaviour
{
    public string sceneName;
    public float delayTime;
    public Image splashscreenImage;
    float transparentValue;

    void Start()
    {
        transparentValue = 0;
        Invoke("changeScene", delayTime);
        StartCoroutine(fadeInScreen());
    }

    void changeScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator fadeInScreen()
    {
        yield return new WaitForSeconds(delayTime - 0.5f);
        if(transparentValue < 255) {
            transparentValue += 1;
        }
        else {
            StopCoroutine("fadeInScreen");
        }

        splashscreenImage.color = new Color(0, 0, 0, transparentValue);
    }
}
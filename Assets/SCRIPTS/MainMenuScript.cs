using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Text bestScore;

    public void PlayButton()
    {
        if(PlayerPrefs.GetInt("Level") < 2)
        SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
    }

    private void Start()
    {
        bestScore.text = "Najbolji skor: " + PlayerPrefs.GetInt("Highscore").ToString();
    }

    public void IgrajBeskonacniMod()
    {
        SceneManager.LoadScene(1);
    }
}

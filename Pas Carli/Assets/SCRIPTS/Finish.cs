using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private int level;

    public void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("Level", level);
        SceneManager.LoadScene(level);

    }

}

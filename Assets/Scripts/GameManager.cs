using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] GamePannels;

    private void Start()
    {
        for (int i = 0; i < GamePannels.Length; i++)
        {
            GamePannels[i].SetActive(false);
        }
    }

    public void ShowPannels(int index)
    {
        GamePannels[index].SetActive(true);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}

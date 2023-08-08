using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneProgressionMechnsim : MonoBehaviour
{
    public int nextScene;
    public GameObject hintPanel;
    void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }

    
    public void SetNextScene()
    {
        PlayerPrefs.SetInt("CurrentLevel", nextScene);
        Debug.Log($"NextScene== {nextScene}");
    }

    public void HintButton(int hintIndex)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Hint", hintIndex);
        PlayerPrefs.SetInt("SceneIndex", sceneIndex);
        SceneManager.LoadScene("Hint");
        hintPanel.SetActive(false);

    }


    public void HintPanelSetActive()
    {
        hintPanel.SetActive(true);
    }

    public void HintPanelSetDeactive()
    {
        hintPanel.SetActive(false);
    }
}

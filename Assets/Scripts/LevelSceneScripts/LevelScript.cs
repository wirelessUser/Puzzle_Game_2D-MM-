using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelScript : MonoBehaviour
{
    public static LevelScript instance;
   public  List<Button> LevelButtonsList = new List<Button>();

   public  int currentLevel;

    private void Awake()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PlayerPrefs.DeleteAll();
        }
        if (instance==null)
        {
            instance = this;
        }
        SetKeyPlayerPref();
        MakeButtonsActivate();
    }

    #region NORMAL CODE.............

    //public void LoadlevelButton(string levelName )
    //{

    //    UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);

    //}


    //public void QuitLevel()
    //{

    //        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");


    //}

    #endregion

    public void SetKeyPlayerPref()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
             currentLevel = PlayerPrefs.GetInt("CurrentLevel");  
        }
        else
        {
            PlayerPrefs.SetInt("CurrentLevel", 2);
        }
       
    }

    public void SetLevel(int levelCount)
    {
        currentLevel = levelCount;
    }

    public void MakeButtonsActivate()
    {
        for (int i = 0; i < LevelButtonsList.Count; i++)
        {
            LevelButtonsList[i].interactable = true;
            if (i+2 >currentLevel)
            {
                LevelButtonsList[i].interactable = false;
            }
        }
    }


    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

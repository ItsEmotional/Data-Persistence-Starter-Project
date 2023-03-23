using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuManager : MonoBehaviour
{
    public GameObject inputField;
    public string playerName;
    public Button startButton;
    public Text inputfText;
    public DataManager dataManager;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartNew);
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();

    }

    public void StartNew()
    {
        playerName = inputfText.GetComponent<Text>().text;

        if (playerName != "")
        {
            dataManager.userName = playerName;
            SceneManager.LoadScene(1);
        }
    }

    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }


}

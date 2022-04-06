using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject inputField;
    public string userName;
    public Button startButton;
    public Text record;
    public Text recordHolder;


    void Start()
    {
        startButton.onClick.AddListener(StartNew);

        record.text = "Record: " + DataManager.Instance.bestScore.ToString();
        recordHolder.text = "Record Holder: " + DataManager.Instance.bestScoreHolder;
    }

    public void StartNew()
    {
        userName = inputField.GetComponent<Text>().text;
        if (userName != "")
        {
            DataManager.Instance.currentUserName = userName;
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

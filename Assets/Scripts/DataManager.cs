using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string userName;
    public GameData SaveData;

        private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }    
    }



    [System.Serializable]
    public class GameData
    {
        public string recordHolder;
        public int record;
    }

    public void SaveScore()
    {
        string saveDataJson = JsonUtility.ToJson(SaveData);
        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");
        File.WriteAllText(path,saveDataJson);
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "SaveData.json");
        if (File.Exists(path))
        {
            string saveDataJson = File.ReadAllText(path);
            SaveData = JsonUtility.FromJson<GameData>(saveDataJson);
        }
    

    }
}

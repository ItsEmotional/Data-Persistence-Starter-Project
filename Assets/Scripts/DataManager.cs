using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string currentUserName;
    public int currentFinalScore;
    public int bestScore;
    public string bestScoreHolder;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        LoadTopScoreData();
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int score;
        public string highScoreHolder;
        public int currentHighScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.score = currentFinalScore;
        

        if (currentFinalScore > bestScore)
        {
            data.currentHighScore = currentFinalScore;
            bestScore = data.currentHighScore;
            data.highScoreHolder = currentUserName;
            bestScoreHolder = data.highScoreHolder;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scoresavefile.json", json);
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.userName = currentUserName;
    
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/namesavefile.json", json);
    }

    public string LoadName()
    {
        string path = Application.persistentDataPath + "/namesavefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
    
            bestScoreHolder = data.highScoreHolder;
        }
    }

    public int LoadBestScore()
    {
        string path = Application.persistentDataPath + "/scoresavefile.json";
        if (File.Exists(path));
        {
           string json = File.ReadAllText(path);
           SaveData data = JsonUtility.FromJson<SaveData>(json);
    
           bestScore = data.currentHighScore;
        }
    }

    public void LoadTopScoreData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
    
            bestScore = data.currentHighScore;
            bestScoreHolder = data.highScoreHolder;
        }
    }

}

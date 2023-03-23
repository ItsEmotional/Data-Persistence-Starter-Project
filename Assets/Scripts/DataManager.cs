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
    public string bestScoreHolder;
    public int bestScore;
    public int score;
    public Text bestScoreText;

        private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
            DontDestroyOnLoad(gameObject);
            LoadData();
            MenuScore();
    }



    [System.Serializable]
    class SaveData
    {
        public string recordHolder;
        public int record;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.record = score;

        if (score > bestScore)
        {
            data.record = score;
            bestScore = data.record;
            data.recordHolder = userName;
            bestScoreHolder = data.recordHolder;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void MenuScore()
    {
        bestScoreText.text = "Best Score : " + bestScoreHolder + " : " + bestScore;
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.record;
            bestScoreHolder = data.recordHolder;
        }
    }
}

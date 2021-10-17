using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public string playerName;
    public string highScore;
    public int highScorePoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();

    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public string highScore;
        public int highScorePoints;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScore = highScore;
        data.highScorePoints = highScorePoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
            highScorePoints = data.highScorePoints;
        } else
        {
            highScore = $"High Score : 0";
        }
    }
}

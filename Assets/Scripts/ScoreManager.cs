using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int highScore;
    public string playerName;
    public string highScorePlayer;

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayer;
        public int highScore;
    }
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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore()
    {
        if (MainManager.m_Points > highScore)
        {
            highScore = MainManager.m_Points;
            highScorePlayer = playerName;
        }
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScorePlayer = highScorePlayer;
        data.highScore = highScore;

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

            highScorePlayer = data.highScorePlayer;
            highScore = data.highScore;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public string bestScoreName;

    public int bestScore = 0;

    private string dataPath;

    // Start is called before the first frame update
    private void Awake()
    {
        dataPath = Application.persistentDataPath + "savefile.json";

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScoreAndName();
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public string bestScoreName;
        public int bestScore;
    }


    public void SaveBestScoreAndName()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.bestScoreName = bestScoreName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(dataPath, json);
    }

    public void LoadBestScoreAndName()
    {
        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            bestScoreName = data.bestScoreName;
            bestScore = data.bestScore;
        }
    }
}

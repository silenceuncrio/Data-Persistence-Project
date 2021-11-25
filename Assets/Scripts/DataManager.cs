using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public string BestPlayerName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string BestPlayerName;
        public int BestScore;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.BestPlayerName = BestPlayerName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = data.BestPlayerName;
            BestScore = data.BestScore;
        }
        else
        {
            BestPlayerName = "NA";
            BestScore = 0;
        }
    }

}

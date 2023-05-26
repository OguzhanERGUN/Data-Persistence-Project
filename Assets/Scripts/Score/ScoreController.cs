using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime;
using UnityEditor.PackageManager;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int highScore;
    public static ScoreController Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [System.Serializable]
    class SaveData
    {
        public string namePlayer;
        public int highScore;
    }

    public void SetPlayerName(string name)
    {
        SaveData data = new SaveData();
        data.namePlayer = name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("en yüksek skorun sahibi" + data.namePlayer + "oldu");

    }

    public void SetHighScore(int score)
    {
        SaveData data = new SaveData();
        data.highScore = score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log("Score" + data.highScore + "oldu");
    }

    public string GetPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            return data.namePlayer;
        }
        return null;
    }

    public int GetHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Score" + data.highScore + "oldu");
            return data.highScore;
        }
        Debug.Log("Score 0 oldu");
        return 0;

    }

}

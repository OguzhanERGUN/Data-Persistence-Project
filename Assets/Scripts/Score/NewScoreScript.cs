using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class NewScoreScript : MonoBehaviour
{
    public static NewScoreScript instance;
    // Start is called before the first frame update
    private void Awake()
    {
        // start of new code
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    [Serializable]
    class DataBase
    {
        public int highestScore;
        public string highestScorePlayerName;
    }

    public void SaveData(int highscore, string highscoreplayername)
    {
        DataBase data = new DataBase();
        data.highestScore = highscore;
        data.highestScorePlayerName = highscoreplayername;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public int GetHighestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataBase data = JsonUtility.FromJson<DataBase>(json);
            return data.highestScore;
        }
        return 0;
    }

    public string GetHighestScorePlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataBase data = JsonUtility.FromJson<DataBase>(json);
            return data.highestScorePlayerName;
        }
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;
    public int highScore;
    public string highPlayer;
    public string newPlayer;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighscore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highPlayer;
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.highPlayer = highPlayer;
        data.highScore = highScore;

        string savejson = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", savejson);
    }
    public void LoadHighscore()
    {
        string saveFilePath = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(saveFilePath))
        {
            string loadjson = File.ReadAllText(saveFilePath);
            SaveData loaddata = JsonUtility.FromJson<SaveData>(loadjson);

            highPlayer = loaddata.highPlayer;
            highScore = loaddata.highScore;
        }
    }
}

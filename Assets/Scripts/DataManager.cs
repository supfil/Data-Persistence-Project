using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int highScore;
    public string nameHighScore;

    public string nameScore;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadSave();
    }

    [SerializeField]
    class SaveData
    {
        public string nameHighScore;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();

        data.nameHighScore = nameHighScore;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            nameHighScore = data.nameHighScore;
        }
    }
}

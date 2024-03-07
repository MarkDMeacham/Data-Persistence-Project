using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    public static MenuUIHandler Instance;
    public string userName;
    public string highScoreUserName;
    public int highScore = 0;

    private string path;

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        path = Application.persistentDataPath + "/savefile.json";
        LoadSaveData();
    }

    public void StartNew()
    {
        StoreSaveData();
        SceneManager.LoadScene(1);
    }

    public void UpdateUserName(string name)
    {
        userName = name;
    }

    [System.Serializable]
    class SaveData
    {
        public string userName;
        public string highScoreUserName;
        public int highScore;
    }

    public void StoreIfHighScore(int score)
    {
        if(score > highScore)
        {
            highScoreUserName = userName;
            highScore = score;
            StoreSaveData();
        }
    }

    void StoreSaveData()
    {
        SaveData data = new SaveData();
        data.userName = userName;
        data.highScoreUserName = highScoreUserName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    void LoadSaveData()
    {
        if (File.Exists(path))
        {
            SaveData data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            userName = data.userName;
            highScoreUserName = data.highScoreUserName;
            highScore = data.highScore;
        }
    }
}

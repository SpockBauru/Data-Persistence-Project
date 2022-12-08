using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static string PlayerName { get; private set; }
    public static string TopPlayerName { get; private set; }
    public static int TopScore { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    // Save Things
    [System.Serializable]
    class GameData
    {
        public string topPlayerName;
        public int topScore;
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public void SetTopPlayerName(string name)
    {
        TopPlayerName = name;
    }

    public void SetTopScore(int score)
    {
        TopScore = score;
    }

    public void SaveData()
    {
        GameData data = new GameData();
        data.topPlayerName = PlayerName;
        data.topScore = TopScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            TopPlayerName = data.topPlayerName;
            TopScore = data.topScore;
        }
    }
}

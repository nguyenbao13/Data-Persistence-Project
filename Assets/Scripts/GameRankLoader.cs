using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameRankLoader : MonoBehaviour
{
    //Fields for display the player info
    public Text BestPlayerName;
    //Static variables for holding the best player data
    private static int BestScore;
    private static string BestPlayer;
    private void Awake()
    {
        LoadGameRank();
    }
    private void SetBestPlayer()
    {
        if(BestPlayer == null && BestScore == 0)
        {
            BestPlayerName.text = "";
        }
        else
        {
            BestPlayerName.text = "Best score - " + BestPlayer + ": " + BestScore;
        }
    }
    public void LoadGameRank()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        //Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestPlayer = data.TheBestPlayer;
            BestScore = data.HighestScore;
            SetBestPlayer();
        }
    }
    [System.Serializable]
    class SaveData
    {
        public int HighestScore;
        public string TheBestPlayer;
    }
}

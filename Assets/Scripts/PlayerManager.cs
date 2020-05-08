using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using Newtonsoft.Json;


public class PlayerData
{
    public string name { get; set; }
    public int score { get; set; }
    public string date { get; set; }
}


public class PlayerManager : MonoBehaviour
{
    
    public TMP_InputField nameInputField;
    public string playerName;
    public int playerScore;
    private string _PlayerJsonData;

    void Awake() {
         DontDestroyOnLoad (this);
     }

    void Start() {
        playerName = "Unknown";
        playerScore = 0;

        nameInputField.onValueChanged.AddListener(delegate {setPlayerName(); });
    }

    public void setPlayerName() {
        playerName = nameInputField.text;
    }

    public void IncrementPlayerScore(int newScore) {
        playerScore = playerScore + newScore;
    }

    public string getPlayerName() {
        return playerName;
    }

    public int getPlayerScore() {
        return playerScore;
    }

    public void serializePlayer() {
        var playerData = new PlayerData()
         {
            name = getPlayerName(),
            score = getPlayerScore(),
            date = System.DateTime.Now.ToString("MM/dd/yyyy")
        };

         _PlayerJsonData = JsonConvert.SerializeObject(playerData);     
    }


    public void savePlayerJson() {
        var filePath = Path.Combine(Application.persistentDataPath, "PlayerData.dat");  
        File.AppendAllText(filePath, _PlayerJsonData);
    }
}

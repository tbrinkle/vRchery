using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.IO;


public class Player {
    public string playerName;
    public int playerScore;
   // public string date;
}


public class PlayerManager : MonoBehaviour
{

    //public GameObject keyboard;
    public TMP_InputField nameInputField;
    public string playerName;
    public int playerScore;
    //public float playTime;

    void Awake() {
         DontDestroyOnLoad (this);
     }

    void Start() {
        playerName = "Unknown";
        playerScore = 0;
        nameInputField.onValueChanged.AddListener(delegate {setPlayerName(); });
        savePlayer();
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

     public void SaveFile(Player p)
     {
         //string location = Application.persistentDataPath + "/playerdata.dat";
         string location = "Assets/Resources/playerdata.dat";
         JsonSerializer serializer = new JsonSerializer();
         List<Player> playerList = new List<Player>();


         if (File.Exists(location)) {
            using (StreamReader file = File.OpenText(location)) {
                List<Player> playerListData = (List<Player>)serializer.Deserialize(file, typeof (List<Player>));
                playerList = playerListData;
            }
            
            playerList.Add(p);
            var data = JsonConvert.SerializeObject(playerList);
                           
            using (StreamWriter sw = new StreamWriter(location))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, playerList);
            }
            
         } else { 
            FileStream file;
            file = File.Create(location);
            file.Close();
            playerList.Add(p);
            using (StreamWriter sw = new StreamWriter(location))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, playerList);
            }
         }       
     }

    public void savePlayer() {
        Player savePlayer = new Player();
        savePlayer.playerName = getPlayerName();
        savePlayer.playerScore = getPlayerScore();
        SaveFile(savePlayer);
    }

}




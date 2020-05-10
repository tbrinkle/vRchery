using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System.IO;


public class ScoreBoard : MonoBehaviour
{
    public GameObject scoreContainer;

    // Start is called before the first frame update
    void Start()
    {
        loadScoreBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScoreBoard() {
        List<Player> playerData = new List<Player>();
        //string location = Application.persistentDataPath + "/playerdata.dat";
        string location = "Assets/Resources/playerdata.dat";

        JsonSerializer serializer = new JsonSerializer();
        List<Player> playerList = new List<Player>();

        if (File.Exists(location)) {
            using (StreamReader file = File.OpenText(location)) {
                List<Player> playerListData = (List<Player>)serializer.Deserialize(file, typeof (List<Player>));
                playerList = playerListData;
            }

            for (int i = 0; i < playerList.Count; i++)
            {
                string playerName = playerList[i].playerName;
                int playerScore = playerList[i].playerScore;

                GameObject boardName = new GameObject("child");
                GameObject boardScore = new GameObject("child");
                boardName.transform.SetParent(this.transform);
                boardScore.transform.SetParent(this.transform);

                boardName .AddComponent<Text>().text = playerName;
                boardScore .AddComponent<Text>().text = playerScore.ToString();
            }


            
         } else { 
                // No Data to add!
                // Do something with the empty space . . .
         }       
    }
}

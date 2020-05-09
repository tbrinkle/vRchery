using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    }

    void Update()
    {
        
    }

    public void setPlayerName() {
        //keyboard.SetActive(true);
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

}

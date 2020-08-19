using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GameStatus : MonoBehaviour {

    

}

/*
{

    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f; 
    [SerializeField] int pointsPerBlockDestroyed = 83; 
    [SerializeField] TextMeshProUGUI scoreText; 
    // state variables 
    [SerializeField] int currentScore = 0; 

    // implements the singleton pattern
    void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length; 
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);   
            Destroy(gameObject); 
        } else {
            DontDestroyOnLoad(gameObject); 
        }
    }

    void Start() {
        scoreText.SetText(currentScore.ToString()); 
    }

    void Update() {
        Time.timeScale = gameSpeed; 
    }

    public void addToScore() {
        currentScore += pointsPerBlockDestroyed; 
        scoreText.SetText(currentScore.ToString()); 
    }

    public void resetGameStatus() {
        Destroy(gameObject); 
    }

    public void testDebug() {
        Debug.Log("the game status is correct"); 
    }

    override public string ToString() {
        return "score: " + currentScore.ToString(); 
    }

}
*/
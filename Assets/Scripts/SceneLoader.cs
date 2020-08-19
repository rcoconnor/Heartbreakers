using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneLoader : MonoBehaviour {
    [SerializeField] string gameOverSceneName; 
    GameManager gameManager; 


    private void Start() {
        Debug.Log("SceneLoader start called"); 
        gameManager = GetComponent<GameManager>(); 
    }


    
    public void loadGameOverScene() {
        Debug.Log("calling SceneLoader"); 
        SceneManager.LoadScene(gameOverSceneName); 
    }

    public void loadNextScene() {
        int curSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(curSceneIndex + 1); 
    }

    public void loadStartScene() {
        SceneManager.LoadScene(0); 
        gameManager = FindObjectOfType<GameManager>(); 
        gameManager.resetGame(); 
        
    }

    public bool isMenuScene() {
        // FIXEME: find a more elegant solution 
        string sceneName = SceneManager.GetActiveScene().name; 
        if (sceneName == "GameOver" || sceneName == "Start Menu") {
            return true; 
        } 
        return false; 
    }


    public void quitGame() {
        Application.Quit(); 
    }

}

/*
{

    [SerializeField] string gameOverSceneName; 

    GameStatus gameStatus; 

    private void Start() {
        gameStatus = GetComponent<GameStatus>(); 
    }

    // loads the next scene in the build editor // 
    public void loadNextScene() {
            int curSceneIndex = SceneManager.GetActiveScene().buildIndex; 
            SceneManager.LoadScene(curSceneIndex + 1);   
    }

    public void loadStartScene() {
        Debug.Log("load start scene called"); 
        gameStatus.resetGameStatus(); 
        SceneManager.LoadScene(0); 
    }


    public void loadGameOverScene() {
        SceneManager.LoadScene(gameOverSceneName); 
    }

   
    
    public int getBuildIndex() {
        int buildIndex = SceneManager.GetActiveScene().buildIndex; 
        onNewScene(); 
        return buildIndex; 
    }

    // Handle Scene Loading // 
    public void onNewScene() {
        Debug.Log("SceneLoad.onNewScene called"); 
        gameStatus = GetComponent<GameStatus>(); 
        Debug.Log("gameStatus: " + gameStatus.ToString()); 
    }

}
*/


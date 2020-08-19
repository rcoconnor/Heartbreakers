using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement; 
using TMPro; 

public class GameManager : MonoBehaviour {
    // member variables 
    [SerializeField] int numLives = 3; 
    [SerializeField] int numBlocks; 

    // objects within the scene which we may need // 
    [SerializeField] BallController ballController; 
    GameObject hearts; 

    // handling score // 
    [SerializeField] TextMeshProUGUI scoreText; 
    [SerializeField] int pointsPerBlockDestroyed = 83; 
    [SerializeField] int currentScore = 0; 

    //GameStatus gameStatus; 
    [SerializeField] SceneLoader sceneLoader; 

    

    // implements the singleton pattern //
    void Awake() {
        int gameManagerCount = FindObjectsOfType<GameManager>().Length; 
        if (gameManagerCount > 1) {
            gameObject.SetActive(false); 
            Destroy(gameObject); 
        } else {
            DontDestroyOnLoad(gameObject); 
        }
    }


    void Start() {
        currentScore = 0; 
        scoreText.SetText(currentScore.ToString()); 
    }

    // Methods for handling the hearts // 

    // Decrements numBlocks by 1, if numBlocks == 0, loads the next scene
    public void decremetNumBlocks() {
        numBlocks--; 
        if(numBlocks == 0) {
            sceneLoader.loadNextScene(); 
        }
    }

    // Adds pointsPerBlockDestroyed to the player score 
    public void addToScore() {
        currentScore += pointsPerBlockDestroyed; 
        scoreText.SetText(currentScore.ToString()); 
    }

    // returns the gameobject containing the hearts 
    private GameObject findHearts() {
        GameObject[] objects = FindObjectsOfType<GameObject>(); 
        for (int i = 0; i < objects.Length; i++) {
            if (objects[i].name == "Blocks") {
                return objects[i]; 
            }
        }
        Debug.Log("error: couldn't find hearts"); 
        throw new System.Exception(); 
    }

    // decrements numLives by 1, then respawns the ball, if numLives = 0 -> gameOver
    public void subtractLives() {
        numLives--; 
        if (numLives <= 0) {
            sceneLoader.loadGameOverScene(); 
        } else {
            ballController.respawn(); 
        }
    }

    //  handle loading new levels // 
    private void OnEnable() {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;     
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading; 
    }

    private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
        sceneLoader = GetComponent<SceneLoader>(); 
        if (sceneLoader == null) {
            Debug.Log("GameManager.OnLevelFinishedLoading error: sceneLoader is null"); 
            throw new System.Exception(); 
        }
        if(sceneLoader.isMenuScene()) {
            hearts = null; 
            ballController = null; 
            scoreText.SetText(""); 
        } else {
            setUpNewLevel(); 
        }
        
    }

    private void setUpNewLevel() {
        hearts = findHearts(); 
         numBlocks = hearts.transform.childCount;
        ballController = FindObjectOfType<BallController>();  
        scoreText.SetText(currentScore.ToString()); 
    }

    // resets all elements that need to be reset to create a new session
    public void resetGame() {
        numLives = 3; 
        currentScore = 0;     
    }

}

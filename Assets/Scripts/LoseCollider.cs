using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoseCollider : MonoBehaviour
{
    [SerializeField] GameManager gameManager; 

    private void Start() {
        gameManager = FindObjectOfType<GameManager>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        gameManager.subtractLives(); 
    }
}

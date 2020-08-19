using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    [SerializeField] Sprite[] sprites; 
    [SerializeField] AudioClip[] clips; 
    [SerializeField] GameObject blockSparklesVFX; 

    GameManager gameManager;
    GameStatus gameStatus;  
    SpriteRenderer spriteRenderer;
    PolygonCollider2D polyCollider;  
    AudioSource audioSource; 
    int curIndex; 

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        polyCollider = GetComponent<PolygonCollider2D>(); 
        curIndex = 0; 
        spriteRenderer.sprite = sprites[curIndex]; 
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = clips[0]; 
        gameManager = FindObjectOfType<GameManager>(); 
    }


    private void OnCollisionEnter2D(Collision2D collisionInfo) {
        if (collisionInfo.gameObject.name == "Ball") {
            curIndex++; 
            updateAudio(); 
            AudioSource.PlayClipAtPoint(audioSource.clip, Camera.main.transform.position); 
            if (curIndex == sprites.Length) {
                polyCollider.enabled = false; 
                spriteRenderer.enabled = false; 
                gameManager.decremetNumBlocks(); 
                gameManager.addToScore(); 
                triggerSparklesVFX(); 
                Destroy(gameObject); 
            } else {
                updateSprite(); 
            }
        }
    }


    private void updateAudio() { 
        if (curIndex == sprites.Length) {
            audioSource.clip = clips[1]; 
        }
    }

    private void updateSprite() {
        spriteRenderer.sprite = sprites[curIndex]; 
    }

    private void triggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation); 
        Destroy(sparkles, 1f); 
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] AudioClip[] clips; 

    AudioSource audioSource; 

    // Start is called before the first frame update
    void Start() {
        audioSource = GetComponent<AudioSource>(); 
    }

    // Called when an object collides with the gameObject
    private void OnCollisionEnter2D(Collision2D collisionInfo) {
        // Handle ball collisions 
        if (collisionInfo.gameObject.name == "Ball") {
            AudioSource.PlayClipAtPoint(clips[0], Camera.main.transform.position); 
        }
    }

}

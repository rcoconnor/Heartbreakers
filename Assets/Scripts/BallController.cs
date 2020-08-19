using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    // config params
    [SerializeField] PaddleController paddle1; 
    [SerializeField] float xPush = 2f; 
    [SerializeField] float yPush = 2f; 
    [SerializeField] float constantSpeed = 15f; 
    [SerializeField] float minYVelocity = 0.2f; 

    //AudioSource audioSource; 
    
    // State
    Vector2 paddleToBallVector; 
    bool hasStarted; 
    Rigidbody2D rb2d; 
    TrailRenderer trailRenderer; 

    // Start is called before the first frame update
    void Start() {
        paddleToBallVector = transform.position - paddle1.transform.position; 
        rb2d = GetComponent<Rigidbody2D>(); 
        trailRenderer = GetComponent<TrailRenderer>(); 
        hasStarted = false; 
        //audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {   
            trailRenderer.enabled = false; 
            lockBallToPaddle();
            launchOnMouseClick();
        } else {
            if (trailRenderer.enabled == false) {
                trailRenderer.enabled = true; 
            }
            if (isPerpindicular()) {
                adjustAngle(); 
            }
            updateSpeed(); 
        }
    }

    public void respawn() {
        trailRenderer.enabled = false; 
        hasStarted = false; 
    }

    private void updateSpeed() {
    
        rb2d.velocity = constantSpeed * (rb2d.velocity.normalized);
    
    }

    private void launchOnMouseClick() {
    
        if (Input.GetKeyUp(KeyCode.Space)) {
            rb2d.velocity = new Vector2 (xPush, yPush ); 
            hasStarted = true; 
        }
    
    }

    private void lockBallToPaddle() {

        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;

    }


    private bool isPerpindicular() {
        Vector3 velocity = new Vector3(rb2d.velocity.x, rb2d.velocity.y, 0); 
        Vector2 curVelocity = rb2d.velocity.normalized; 
        if (Mathf.Abs(curVelocity.y) < minYVelocity) { 
            Debug.DrawRay(transform.position, velocity, new Color(0f, 255f, 0f, 255f), 3f); 
            return true; 
        } 
        return false; 
    }

    private void adjustAngle() {
        Vector2 offset; 
        Vector2 curVelocity = rb2d.velocity.normalized; 
        if (curVelocity.x > 0) {
            // Going to the right, so we should subtract from x 
            if (curVelocity.y > 0) {
                // going to the up, so we should increase y value 
                offset = new Vector2(-minYVelocity, minYVelocity); 
                rb2d.velocity += offset.normalized; 
            } else {
                // going down, so we should decrease the y value 
                offset = new Vector2(-minYVelocity, -minYVelocity); 
                rb2d.velocity += offset.normalized; 
            }
        } else {
            // going to the left, so we should add to x 
            if (curVelocity.y > 0) {
                // going up, so we should increase y
                offset = new Vector2(minYVelocity, minYVelocity); 
                rb2d.velocity += offset.normalized; 
            } else {
                // goind down, so we should decrease y
                offset = new Vector2(minYVelocity, -minYVelocity); 
                rb2d.velocity += offset.normalized; 
            }
        }
    }

    private void DrawDebugRay(float count, float r, float g, float b) {
        Vector3 curPos = transform.position; 
        Vector2 velocity = rb2d.velocity; 
        Vector3 pointToDraw = new Vector3(velocity.x, velocity.y, 0); 

        Debug.DrawRay(curPos, pointToDraw, new Color(r, g, b, 240f), count); 
    }

    private void printVector(Vector2 velocity) {
        Debug.Log("(" + rb2d.velocity.x + ", " + rb2d.velocity.y + ")"); 
    }

}


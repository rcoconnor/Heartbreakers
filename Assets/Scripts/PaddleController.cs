using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Controller to move the paddle on the x axis in line with our mouse cursor
 *
 */ 
public class PaddleController : MonoBehaviour
{

    [SerializeField] float screenWdithInUnits = 16f; 
    [SerializeField] float minX = 1f; 
    [SerializeField] float maxX = 15f; 
    [SerializeField] float movementSpeed; 


    // Update is called once per frame
    void Update() {
        //Find the position of the mouse as it moves
        // conver the mouse's position into world units 
        // update the paddles position
        
        updatePaddle(); 
    }

    
    private Vector3 getNewPaddlePos() {
        Vector3 newPos = new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        return newPos;  
    }

    void updatePaddle() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.position -= getNewPaddlePos(); 
        } else if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += getNewPaddlePos(); 
            
        }
        
        transform.position = clampPaddle(); 
    }

    private Vector3 clampPaddle() {
        Vector3 clampedPos = transform.position; 
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX); 
        return clampedPos; 
    }

}

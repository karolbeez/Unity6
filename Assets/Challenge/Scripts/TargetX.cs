using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetX : MonoBehaviour
{
    private Rigidbody rb;
    private GameManagerX gameManagerX;
    public int pointValue;
    public GameObject explosionFx;
    public bool skull;

    private float minValueX = -3.75f; // the x value of the center of the left-most square
    private float minValueY = -3.75f; // the y value of the center of the bottom-most square
    private float spaceBetweenSquares = 2.5f; // the distance between the centers of squares on the game board
    

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition();

    }

    // When target is clicked, destroy it, update score, and generate explosion if object is bad - GameOver
    private void OnMouseDown()
    {
        if (skull == true)
        {
            gameManagerX.GameOver();
            
        }
        if (gameManagerX.isGameActive)
        {
            Destroy(gameObject);
            gameManagerX.UpdateScore(pointValue);
            Explode();
        }

               
    }
    
    Vector3 RandomSpawnPosition()
    {

      
        float spawnPosX = RandomSquareIndex() * spaceBetweenSquares + minValueX;
        float spawnPosY = RandomSquareIndex() * spaceBetweenSquares + minValueY;

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        
        
        
        return spawnPosition;

    }
    
    int RandomSquareIndex ()
    {
        return Random.Range(0, 4);
    }

    void Explode ()
    {
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
    }



}

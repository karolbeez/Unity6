using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectSkullX : MonoBehaviour
{
    void Start()
    {
        // destroy particle after delay
        Destroy(gameObject, 2);
        
        dest.GameOver();
    }
public GameManagerX dest = new GameManagerX();
    public void GameOver()
    {
        dest.gameObject.SetActive(true);
        dest.gameObject.SetActive(true);
        dest.isGameActive = false;
    }
    
}

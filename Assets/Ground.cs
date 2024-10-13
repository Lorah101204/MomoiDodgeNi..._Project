using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public Transform player; 
    public float wallPositionY;  
    void Update()
    {
        if (player.position.x < wallPositionY)
        {
            player.position = new Vector2(wallPositionY, player.position.x);
        }
    }
}
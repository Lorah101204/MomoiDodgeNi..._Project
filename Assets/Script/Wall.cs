using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Transform player; 
    public float wallPositionX;  

    void Update()
    {
        if (player.position.x > wallPositionX)
        {
            player.position = new Vector2(wallPositionX, player.position.y);
            
            /*Cách 2: Hoặc bạn có thể thiết lập vận tốc để dừng player
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }*/
        }
    }
}
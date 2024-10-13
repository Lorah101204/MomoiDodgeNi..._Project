using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NigaDeleter : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger has a Rigidbody2D (optional check)
        if (other.attachedRigidbody != null)
        {
            // Destroy the falling object
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

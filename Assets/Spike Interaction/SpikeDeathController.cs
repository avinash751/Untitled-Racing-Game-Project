using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeathController : MonoBehaviour
{
    Respawn playerrespawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
<<<<<<< Updated upstream
=======

   void OnCollisionEnter2D(Collision2D collision)
    {
        playerrespawn = collision.gameObject.GetComponent<Respawn>();

        if (collision.gameObject.CompareTag("Player") && !playerrespawn.ignoreObstacleCollision)
        {
            collision.gameObject.SetActive(false);
        }
    }
>>>>>>> Stashed changes
}

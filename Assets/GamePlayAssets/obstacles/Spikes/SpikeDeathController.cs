using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDeathController : MonoBehaviour
{
    public Respawn playerrespawn;

    //Andrew's Code
   void OnCollisionEnter2D(Collision2D collision)
    {
        playerrespawn = collision.gameObject.GetComponent<Respawn>();
        if (collision.gameObject.CompareTag("Player") && !playerrespawn.ignoreObstacleCollision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}

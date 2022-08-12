using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] bool Repositioned;
    [SerializeField] public bool ignoreObstacleCollision;
    [SerializeField] List<Collider2D> ObstacleColliders = new List<Collider2D>();
    [SerializeField] float DurationOfInvulnurability;
    bool runOnce;

    private void OnDisable()
    {
        if(Repositioned)
        {
            Repositioned = false;
            Invoke(nameof(ReactivatePlayer), 1.5f);
        }
       
    }

    private void OnEnable()
    {
        if(!Repositioned)
        {
            RepsoitionPlayer();
            StartCoroutine(ReSetInvulnerability());
            Repositioned=true;
        }
    }

    void ReactivatePlayer()
    {
        gameObject.SetActive(true);
        Debug.Log("reactivated");
    }
    void RepsoitionPlayer()
    {
        gameObject.transform.position = new Vector2(Camera.main.transform.position.x, -3.52f);
    }

    IEnumerator ReSetInvulnerability()
    {
       ignoreObstacleCollision = true;
        yield return new WaitForSeconds(DurationOfInvulnurability);
        ignoreObstacleCollision = false;
        foreach (Collider2D obstacle in ObstacleColliders)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obstacle,false);
            Debug.Log("collider working");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(ignoreObstacleCollision)
        {
            if(collision.gameObject.tag == "Spike")
            {
                ObstacleColliders.Add(collision.gameObject.GetComponent<Collider2D>());
            }

            foreach(Collider2D obstacle in ObstacleColliders)
            {
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), obstacle);
            }
        }
    }




}

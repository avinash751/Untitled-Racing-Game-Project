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
    [SerializeField] float ThresholdForDefaultReposition;

    private void OnDisable()
    {
        if(Repositioned)
        {
            GetComponent<ColorBlinker>().EnableColorBlinking(true);
            Repositioned = false;
            Invoke(nameof(ReactivatePlayer), 1.5f);
        }
       
    }

    private void OnEnable()
    {
        if(!Repositioned)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<TrailRenderer>().enabled = true;
            RepsoitionPlayer();
            StartCoroutine(ReSetInvulnerability());
            Repositioned=true;
        }
    }

    void ReactivatePlayer()
    {
        gameObject.SetActive(true);
        //Debug.Log("reactivated");
    }
    void RepsoitionPlayer()
    {
        if(Camera.main.transform.position.x < ThresholdForDefaultReposition)
        {
            gameObject.transform.position = new Vector2(Camera.main.transform.position.x, -3.52f);
        }
        else
        {
            gameObject.transform.position = new Vector2(Camera.main.transform.position.x -6, -3.52f);
        }
       
    }

    IEnumerator ReSetInvulnerability()
    {
       ignoreObstacleCollision = true;
        yield return new WaitForSeconds(DurationOfInvulnurability);
        ignoreObstacleCollision = false;

    }

   




}

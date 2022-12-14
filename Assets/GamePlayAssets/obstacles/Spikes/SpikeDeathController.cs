using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpikeDeathController : MonoBehaviour
{
    public Respawn playerrespawn;
    public CameraShakeAHR camerashake;
    //Andrew's Code
    void OnCollisionEnter2D(Collision2D collision)
    {
        playerrespawn = collision.gameObject.GetComponent<Respawn>();
        if (collision.gameObject.CompareTag("Player") && !playerrespawn.ignoreObstacleCollision)
        {
            camerashake.SetCameraShakeValues(55, 0.2f, 0.3f);
            camerashake.EnableCamersShake(true);

            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(DisableGameObjectAfterDelay(1f, collision.gameObject));
            collision.gameObject.GetComponent<SpawnParticlesOnCollsion>().SpawnParticleSystemThenDestroy(collision.transform); // line added by avinash , adding partcile system
            collision.gameObject.GetComponent<SpawnParticlesOnCollsion>().DoExtraThingsOnCollision.Invoke();
        }
    }


    IEnumerator DisableGameObjectAfterDelay(float delayTime,GameObject ObjectToDisable)
    {
        yield return new WaitForSeconds(delayTime);
        ObjectToDisable.gameObject.SetActive(false);
    }
}

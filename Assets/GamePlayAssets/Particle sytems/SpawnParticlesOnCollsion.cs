using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnParticlesOnCollsion : MonoBehaviour
{
    [SerializeField] string CollsionTag;
    [SerializeField] GameObject ParticleSystem;
    [SerializeField] float ParticleDestroyTimer;
    [SerializeField] Vector3 SpawnPositionOffset;

    [Header("DO more after collsion,if needed")]
    [SerializeField] UnityEvent DoExtraThingsOnCollision;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == CollsionTag)
        {
            SpawnParticleSystemThenDestroy(collision.transform);
            DoExtraThingsOnCollision.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == CollsionTag)
        {
            SpawnParticleSystemThenDestroy(collision.transform);
            DoExtraThingsOnCollision.Invoke();
        }
    }

    public void SpawnParticleSystemThenDestroy(Transform spawnTransform )
    {
        GameObject duplicate = Instantiate(ParticleSystem, spawnTransform.position + SpawnPositionOffset, ParticleSystem.transform.rotation);
        DestroyParticleSystem(duplicate);
    }

    public void DestroyParticleSystem(GameObject ParticleSystemToDestroy)
    {
        Destroy(ParticleSystemToDestroy, ParticleDestroyTimer);
    }

    

}

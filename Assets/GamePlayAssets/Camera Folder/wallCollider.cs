using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallCollider : MonoBehaviour
{
    public CameraShakeAHR camerashake;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camerashake.SetCameraShakeValues(55, 0.2f, 0.3f);

            camerashake.EnableCamersShake(true);
            

            collision.gameObject.GetComponent<SpawnParticlesOnCollsion>().DoExtraThingsOnCollision.Invoke(); // this is for playing the sound fcuntion from the do extrathings on collsion event from the player game object
            StartCoroutine(DisableGameObjectAfterDelay(0.5f, collision.gameObject)); 
            Debug.Log ("object disabled");
        }
    }

    IEnumerator DisableGameObjectAfterDelay(float delayTime, GameObject ObjectToDisable) // a delay function , when called you can specify which game object to disable and amount of duration, normally not possible with invoke
    {
        yield return new WaitForSeconds(delayTime);
        ObjectToDisable.gameObject.SetActive(false);
    }
}

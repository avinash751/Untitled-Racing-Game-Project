using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorOnHit : MonoBehaviour

{
    SpriteRenderer coloreto;

    public bool Startlurping;
    
    void Start()
    {
        coloreto = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvrtPOW"))
        {

            coloreto.color = new Color(3, 0, 2);


            Startlurping = true;

            
            
        }
    }

  

    void Update()
    {   if (Startlurping)
        {
            coloreto.color = Color.Lerp(coloreto.color, Color.black, Time.deltaTime / 2f);
        }
        
            

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorOnHit : MonoBehaviour

{

    public Color colortolerp;
    SpriteRenderer coloreto;
    public Color startColor;
    public float elapsedTime;

    public bool Startlurping;
    
    void Start()
    {
        coloreto = GetComponent<SpriteRenderer>();
        startColor = coloreto.color; // getting sprite initial start color
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvrtPOW") && !collision.gameObject.GetComponent<InvertPWUPController>().inverted)
        {

            coloreto.color = new Color(colortolerp.r, colortolerp.g, colortolerp.b);


            Startlurping = true;  
        }
    }


    void Update()
    { 
       
        if (Startlurping )
        {
            elapsedTime += Time.deltaTime;
            coloreto.color = Color.Lerp(coloreto.color, startColor, Time.deltaTime / 4f);
        }
        
            

    }
}

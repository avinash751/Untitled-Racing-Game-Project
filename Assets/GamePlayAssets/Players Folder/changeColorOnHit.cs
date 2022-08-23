using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorOnHit : MonoBehaviour

{
    SpriteRenderer coloreto;
    void Start()
    {
        coloreto = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        coloreto.color = new Color(2, 0, 0);
    }

    void Update()
    {
        coloreto.color = Color.Lerp(coloreto.color, Color.red, Time.deltaTime / 2.5f);

        
    }
}

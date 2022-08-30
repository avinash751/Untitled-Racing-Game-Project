using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertAuraController : MonoBehaviour
{
    public Color purpleColor, transparentColor;
    Color currentColor;
    MeshRenderer myRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = purpleColor;
        currentColor = transparentColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InvertPOW"))
        {
            if (currentColor == transparentColor)
            {
                currentColor = purpleColor;
            }
            else
            {
                currentColor = transparentColor;
            }
        }

        myRenderer.material.color = Color.Lerp(myRenderer.material.color, currentColor, 0.1f);
    }
}

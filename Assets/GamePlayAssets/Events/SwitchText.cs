using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SwitchConfirm")
        {
            textMeshPro.enabled = true;
            Debug.Log("Sides Switched");
        }
    }
}

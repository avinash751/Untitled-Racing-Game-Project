using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlinker : MonoBehaviour
{
    [SerializeField] float TimeElapsed;
    [SerializeField] bool StartBlinking;
    [Header("Color Blibker Settings")]
    [SerializeField] SpriteRenderer SpriteToBlink;
    [SerializeField] Color originalColor;
    [SerializeField] Color ColorToBlinkTo;
    [SerializeField] float Duration;
    [SerializeField] float Frequency;
    [SerializeField] float Amplitude;
    
    // Start is called before the first frame update
    void Start()
    {

        GetOriginalColorOfSprite();
    }

    // Update is called once per frame
    void Update()
    {
        StartColorBlinking();
    }


    void GetOriginalColorOfSprite()
    {
        originalColor = SpriteToBlink.color;
    }
    void StartColorBlinking()
    {
        if(Duration>TimeElapsed && StartBlinking)
        {
            TimeElapsed += Time.deltaTime;
            SpriteToBlink.color = Color.Lerp(originalColor, ColorToBlinkTo, Amplitude * Mathf.Sin(Time.time *Frequency));
        }
    }

    public void EnableColorBlinking(bool enable)
    {
        StartBlinking = enable;
        ResetTimeElapsed();
    }

    void ResetTimeElapsed()
    {
        TimeElapsed = 0;
    }


}



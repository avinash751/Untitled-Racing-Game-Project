using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayASound : MonoBehaviour
{
    public  AudioSource[] AllAudioSources;
    [SerializeField] int AmmountOfAudioSourcessRequired;
    int index;

    [Header("Audio Clip Settings")]
    [SerializeField] AudioClip AudioFile;
    [Range(0, 1)][SerializeField] float AudioVolume;
    [Range(0, 3)][SerializeField] float AudioPitch;
    
   

    
    // Start is called before the first frame update
    void Start()
    {
     
        CreateAllAudioSources();
        InitailizeAllAudioSourceValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateAllAudioSources()
    {
        AllAudioSources = new AudioSource[AmmountOfAudioSourcessRequired];
        for (int i = 0; i < AmmountOfAudioSourcessRequired; i++)
        {

            AllAudioSources[i] = gameObject.AddComponent<AudioSource>();
            
        }
    }

    void InitailizeAllAudioSourceValues()
    {
        foreach(AudioSource a in AllAudioSources)
        {
            a.clip = AudioFile;
            a.volume = AudioVolume;
            a.pitch = AudioPitch;
            a.playOnAwake = false;
            Debug.Log(a);
        }
    }

    public void PlaySound()
    {
        if (index == AmmountOfAudioSourcessRequired)
        {
            index = 0;
        }
        if (index<AmmountOfAudioSourcessRequired)
        {
            AllAudioSources[index].Play();
            index++;
            Debug.Log("sound played");
        }
        
    }

   


   
}

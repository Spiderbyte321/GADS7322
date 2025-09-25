using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private string[] soundKeys;
    [SerializeField] private AudioClip[] soundValues;
    [SerializeField] private AudioSource speaker;

    private Dictionary<string, AudioClip> soundEFfects = new Dictionary<string, AudioClip>();
    
    
    public static SoundManager Instance;


    private void Awake()
    {
        if(Instance is null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
            Instance = this;
        }

        for(int i=0;i<soundKeys.Length;i++)
        {
            soundEFfects.Add(soundKeys[i],soundValues[i]);
        }
    }



    public void PlaySoundEffect(string Akey)
    {
        speaker.clip = soundEFfects[Akey];
        speaker.Play();
    }

    private void OnValidate()
    {
        if(soundKeys.Length > soundValues.Length)
        {
            Array.Resize(ref soundValues,soundKeys.Length);
            Debug.Log("not enough values resizing array");
        }
    }
}

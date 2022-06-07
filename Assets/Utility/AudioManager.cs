using System.Collections;
using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager _instance;

    void Awake()
    {   
        if(_instance == null)
        {
            _instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("La canción " + name + " no se encuentra.");
            return;
        }
        s.source.Play();
    }

    void Start()
    {
        StartCoroutine(PlayRandomSong());
        //Play("MainTheme");

      
    
    }
    void Update()
    {
      
    }

    IEnumerator PlayRandomSong()
    {
        Sound currentSong;
       
        currentSong = sounds[UnityEngine.Random.Range(0, sounds.Length - 1)];
        Play(currentSong.name);
        yield return new WaitForSeconds(currentSong.clip.length);
        
    }
}

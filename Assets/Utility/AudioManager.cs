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
            Debug.LogWarning("La canción " + " no se encuentra.");
            return;
        }
        s.source.Play();
    }

    void Start()
    {
        //meter aqui el tema de inicio: Play("*inserte aqui el nombre de la cancion*"); // Serializar una variable Sound donde meter la cancion
    }
  
}

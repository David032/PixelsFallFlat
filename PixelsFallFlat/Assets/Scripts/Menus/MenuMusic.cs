using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    public AudioClip menu_music;
    public AudioSource audio_source;

    bool current_state;
    bool last_state;

    //plays music as the menu is opened
    void Start()
    {
        current_state = true;
        last_state = true;

        audio_source.clip = menu_music;
        audio_source.Play();
    }

    void Update()
    {
        if (current_state != last_state)
        {
            PlayMusic();
        }
    }

    //allows the state to be changed, for music on/off.
    public void SetNewState(bool music_state)
    {
        current_state = music_state;
    }

    //checks the wether to play the music depending on the current state.
    private void PlayMusic()
    {
        if (current_state)
        {
            audio_source.clip = menu_music;
            audio_source.Play();
            last_state = current_state;
        }
        else
        {
            audio_source.Stop();
            last_state = current_state;
        }
    }

    public bool GetMusicState()
    {
        return current_state;
    }

}

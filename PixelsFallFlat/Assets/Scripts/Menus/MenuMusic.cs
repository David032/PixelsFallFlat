using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    public AudioClip menu_music;
    public AudioClip menu_music_2;
    public AudioSource audio_source;

    void Update()
    {
        float h = Input.GetAxis("P1Vertical");
        float e = Input.GetAxis("P1Grab");

        if (h != 0)
        {
            audio_source.clip = menu_music;
            audio_source.Play();
        }

        if (e != 0)
        {
            audio_source.clip = menu_music_2;
            audio_source.Play();
        }

    }

    public void SetNewState(bool music_state)
    {
        audio_source.mute = music_state;
    }



}

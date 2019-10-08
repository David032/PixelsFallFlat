using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSounds : MonoBehaviour
{
    public AudioSource audio_source;

    public AudioClip shovel;
    public AudioClip axe;
    public AudioClip placePipe;
    public AudioClip cannon;
    public AudioClip explosion;
    public AudioClip fallingTree;
    public AudioClip impact;
    public AudioClip keyuse;
    public AudioClip lever;
    public AudioClip openDoor;
    public AudioClip levelCompleat;
    public AudioClip v1;
    public AudioClip v2;
    public AudioClip v3;
    public AudioClip v4;

    public AudioClip deathScream1;
    public AudioClip deathScream2;
    public AudioClip respawn;

    public void SetNewState(bool music_state)
    {
        audio_source.mute = music_state;
    }

    public void PlayDeath1Sound()
    {
        audio_source.clip = deathScream1;
        audio_source.Play();
    }

    public void PlayDeath2Sound()
    {
        audio_source.clip = deathScream2;
        audio_source.Play();
    }

    public void PlayRespawnSound()
    {
        audio_source.clip = respawn;
        audio_source.Play();
    }

    public void PlayShovelSound()
    {
        audio_source.clip = shovel;
        audio_source.Play();
    }

    public void PlayAxeSound()
    {
        audio_source.clip = axe;
        audio_source.Play();
    }

    public void PlayHammerSound()
    {
        audio_source.clip = shovel; // add hammer if needed
        audio_source.Play();
    }

    public void PlayBreakingSound()
    {
        audio_source.clip = v2;
        audio_source.Play();
    }

    public void PlayTreeSound()
    {
        audio_source.clip = fallingTree;
        audio_source.Play();
    }

    public void PlayDoorOpenSound()
    {
        audio_source.clip = openDoor;
        audio_source.Play();
    }

    public void PlayPipeplaceSound()
    {
        audio_source.clip = placePipe;
        audio_source.Play();
    }

    public void PlayPresurePadSound()
    {
        audio_source.clip = v3;
        audio_source.Play();
    }

    public void PlayUnlockSound()
    {
        audio_source.clip = keyuse;
        audio_source.Play();
    }

    public void PlayNextLevelSound()
    {
        audio_source.clip = levelCompleat;
        audio_source.Play();
    }
}

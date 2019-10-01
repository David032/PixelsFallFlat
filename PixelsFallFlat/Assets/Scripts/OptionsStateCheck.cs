using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionsStateCheck : MonoBehaviour
{

    public GameObject AudioManager;
    public GameObject button_music_on;
    public GameObject button_music_off;

    private bool last_state;
    
    void Start()
    {
        AudioManager = GameObject.FindGameObjectWithTag("AudioManager");
        if (AudioManager.GetComponent<MenuMusic>().GetMusicState())
        {
            EventSystem.current.firstSelectedGameObject = button_music_on;
        }
        else
        {
            EventSystem.current.firstSelectedGameObject = button_music_off;
        }

        last_state = AudioManager.GetComponent<MenuMusic>().GetMusicState();
    }

   
    void Update()
    {
        if (AudioManager.GetComponent<MenuMusic>().GetMusicState() != last_state)
        {
            if (AudioManager.GetComponent<MenuMusic>().GetMusicState())
            {
                EventSystem.current.firstSelectedGameObject = button_music_on;
            }
            else
            {
                EventSystem.current.firstSelectedGameObject = button_music_off;
            }
        }
    }
}

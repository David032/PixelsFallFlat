using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EM_MusicOff : MonoBehaviour
{
    public GameObject music_button;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(music_button);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip WalkingClip;
    public AudioClip grabbingClip;
    public PlayerController.Player pNum = PlayerController.Player.Player1;

    public bool isPlaying = false;

    AudioSource player;
    Vector2 playerVector;
    string grabButton;

    void Start()
    {
        player = GetComponent<AudioSource>();
        playerVector = GetComponent<PlayerController>().playerVelocity;
        grabButton = pNum + "Grab";
         
    }

    private void LateUpdate()
    {
        float x = playerVector.x;
        float y = playerVector.y;

        if (Input.GetButtonDown(grabButton))
        {
            player.clip = grabbingClip;
            isPlaying = true;
            player.Play();
        }

        else if (playerVector != Vector2.zero)
        {
            player.clip = WalkingClip;
            isPlaying = true;
            //player.Play();
        }
    }




}

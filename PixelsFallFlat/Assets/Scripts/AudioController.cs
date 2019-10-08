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
    public Vector2 playerVector;
    string grabButton;

    void Start()
    {
        player = GetComponent<AudioSource>();
        

        switch (pNum)
        {
            case PlayerController.Player.Player1:
                grabButton = "P1Grab";
                break;
            case PlayerController.Player.Player2:
                grabButton = "P2Grab";
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        playerVector = GetComponent<PlayerController>().playerVelocity;

        if (Input.GetButtonDown(grabButton))
        {
            player.clip = grabbingClip;
            isPlaying = true;
            player.Play();
        }

        if (playerVector != Vector2.zero)
        {
            print("Walking!");
            player.clip = WalkingClip;
            isPlaying = true;
            player.Play();
        }
    }




}

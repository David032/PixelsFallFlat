using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDoor1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] pads;
    public Sprite openDoor;
    public Sprite closedDoor;

    public WorldSounds audioManager;

    bool padsActive;
    bool open = false;

    // Update is called once per frame
    void Update()
    {
        padsActive = true;
        foreach (var pad in pads)
        {
            if (!pad.GetComponent<PressurePad>().IsActive)
            {
                padsActive = false;
                break;
            }
        }
        
        if(padsActive == true)
        {
            //door is open
            if (!open)
            {
                audioManager.PlayDoorOpenSound();
                open = true;
            }

            if (GetComponent<RoomChange>() != null)
            {
                GetComponent<RoomChange>().canMove = true;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            this.GetComponent<SpriteRenderer>().sprite = openDoor;
        }
        else
        {
            //door is closed
            open = false;

            if (GetComponent<RoomChange>() != null)
            {
                GetComponent<RoomChange>().canMove = false;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = true;
            }
            this.GetComponent<SpriteRenderer>().sprite = closedDoor;
        }
    }
}

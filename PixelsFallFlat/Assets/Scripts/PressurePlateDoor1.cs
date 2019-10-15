using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDoor1 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pad1;
    public GameObject pad2;
    public bool padBool1;
    public bool padBool2;
    public Sprite openDoor;
    public Sprite closedDoor;

    public WorldSounds audioManager;
    bool open = false;

    // Update is called once per frame
    void Update()
    {
        padBool1 = pad1.GetComponent<PressurePad>().IsActive;
        padBool2 = pad2.GetComponent<PressurePad>().IsActive;

        
        if(padBool1 == true && padBool2 == true)
        {
            //door is open
            if (!open)
            {
                audioManager.PlayDoorOpenSound();
                open = true;
            }
            this.GetComponent<RoomChange>().canMove = true;
            this.GetComponent<SpriteRenderer>().sprite = openDoor;
            GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, 0.034f);
            GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.0123f);
        }
        else
        {
            //door is closed
            open = false;
            this.GetComponent<RoomChange>().canMove = false;
            this.GetComponent<SpriteRenderer>().sprite = closedDoor;
            GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, 0.0f);
            GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.08f);
        }
    }
}

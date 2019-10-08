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
    public GameObject secondDoor;
    public Sprite closedDoor;

    // Update is called once per frame
    void Update()
    {
        padBool1 = pad1.GetComponent<PressurePad>().IsActive;
        padBool2 = pad2.GetComponent<PressurePad>().IsActive;

        
        if(padBool1 == true && padBool2 == true)
        {
            //door is open
            this.GetComponent<RoomChange>().canMove = true;
            this.GetComponent<SpriteRenderer>().sprite = openDoor;

            secondDoor.GetComponent<RoomChange>().canMove = true;
            secondDoor.GetComponent<SpriteRenderer>().sprite = openDoor;
        }
        else
        {
            //door is closed
            this.GetComponent<RoomChange>().canMove = false;
            this.GetComponent<SpriteRenderer>().sprite = closedDoor;

            secondDoor.GetComponent<RoomChange>().canMove = false;
            secondDoor.GetComponent<SpriteRenderer>().sprite = closedDoor;
        }
    }
}

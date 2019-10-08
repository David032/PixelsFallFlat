using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : MonoBehaviour
{
    public bool isDoorOpen;
    public GameObject door;
    public Sprite openedDoor;



    // Update is called once per frame
    void Update()
    {
        isDoorOpen = GetComponent<LockWKey>().doorIsOpen;
         if(isDoorOpen)
        {
            door.GetComponent<RoomChange>().canMove = true;
            door.GetComponent<SpriteRenderer>().sprite = openedDoor;
        }
    }
}

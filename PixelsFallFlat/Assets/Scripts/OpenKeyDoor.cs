using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : MonoBehaviour
{
    public GameObject[] keyLocks;

    bool isDoorOpen;
    public Sprite openedDoor;

    // Update is called once per frame
    void Update()
    {
        isDoorOpen = true;
        foreach (var keyLock in keyLocks)
        {
            if (!keyLock.GetComponent<LockWKey>().doorIsOpen)
            {
                isDoorOpen = false;
                break;
            }
        }

         if(isDoorOpen)
        {
            if (GetComponent<RoomChange>() != null)
            {
                GetComponent<RoomChange>().canMove = true;
            }
            else
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }
            GetComponent<SpriteRenderer>().sprite = openedDoor;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeDoor : MonoBehaviour
{
    public GameObject[] pipeSpots;
    bool pipeBool;
    public Sprite openDoor;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        pipeBool = true;
        foreach (var pipeSpot in pipeSpots)
        {
            if (pipeSpot.GetComponent<PipeInteraction>().pipeComplete == false)
            {
                pipeBool = false;
                break;
            }
        }

        if (pipeBool == true)
        {
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
    }
}

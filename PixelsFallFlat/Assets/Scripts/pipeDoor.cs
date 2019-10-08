using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeDoor : MonoBehaviour
{
    public GameObject pipeSpot1;
    public bool pipeBool1; 
    public GameObject pipeSpot2;
    public bool pipeBool2;
    public Sprite openDoor;
    public GameObject secondDoor;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        pipeBool1 = pipeSpot1.GetComponent<PipeInteraction>().pipeComplete;
        pipeBool2 = pipeSpot2.GetComponent<PipeInteraction>().pipeComplete;


        if(pipeBool1 == true && pipeBool2 == true)
        {
            //door is open
            this.GetComponent<RoomChange>().canMove = true;
            this.GetComponent<SpriteRenderer>().sprite = openDoor;

            secondDoor.GetComponent<RoomChange>().canMove = true;
            secondDoor.GetComponent<SpriteRenderer>().sprite = openDoor;
        }
    }
}

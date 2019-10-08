using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDoor2 : MonoBehaviour
{
    public GameObject pipeSpot3;
    public bool pipeBool3;
    public GameObject pipeSpot4;
    public bool pipeBool4;
    public Sprite openDoor;
    public GameObject secondDoor;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        pipeBool3 = pipeSpot3.GetComponent<PipeInteraction>().pipeComplete;
        pipeBool4 = pipeSpot4.GetComponent<PipeInteraction>().pipeComplete;



        Debug.Log(pipeBool3 + " " + pipeBool4);

        if (pipeBool3 == true && pipeBool4 == true)
        {
            //door is open
            this.GetComponent<RoomChange>().canMove = true;
            this.GetComponent<SpriteRenderer>().sprite = openDoor;

            secondDoor.GetComponent<RoomChange>().canMove = true;
            secondDoor.GetComponent<SpriteRenderer>().sprite = openDoor;
        }
    }
}

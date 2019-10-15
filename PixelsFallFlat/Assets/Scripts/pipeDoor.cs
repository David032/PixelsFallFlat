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
            GetComponent<BoxCollider2D>().offset = new Vector2(0.0f,0.034f);
            GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.0123f);
        }
    }
}

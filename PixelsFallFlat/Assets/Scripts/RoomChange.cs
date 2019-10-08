using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    public GameObject room;
    public GameObject player1_pos;
    public GameObject player2_pos;

    public bool ChangeLevel;
    public bool dissapearingDoor;
    public bool canMove;
    //Build order level, not level number(i.e. level 2 is 3)
    public int levelToLoad;

    public WorldSounds audioManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            if (dissapearingDoor)
            {
                this.GetComponent<SpriteRenderer>().enabled = false;
            }

            if(canMove)
            {
                StartCoroutine(LoadRoom());
            }
            
        }
    }

    IEnumerator LoadRoom()
    {
        yield return new WaitForSeconds(1.5f);
        if (!ChangeLevel)
        {
            GameObject.Find("Main Camera").transform.position = room.transform.position;
            GameObject.Find("Player1").transform.position = player1_pos.transform.position;
            if (GameObject.Find("Player2")) // prevent error messages in consol
            {
                GameObject.Find("Player2").transform.position = player2_pos.transform.position;
            }
        }
        else if (ChangeLevel)
        {
            audioManager.PlayNextLevelSound();
            SceneManager.LoadScene(levelToLoad);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    public GameObject room;
    GameObject player1_pos;
    GameObject player2_pos;

    public bool ChangeLevel;
    public bool dissapearingDoor;
    public bool canMove;
    //Build order level, not level number(i.e. level 2 is 3)
    public int levelToLoad;

    public WorldSounds audioManager;

    private void Start()
    {
        if (!ChangeLevel)
        {
            player1_pos = this.transform.Find("P1Spawn").gameObject;
            player2_pos = this.transform.Find("P2Spawn").gameObject;
        }
    }

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
        yield return new WaitForSeconds(0.01f);
        if (!ChangeLevel)
        {
            GameObject.Find("Main Camera").transform.position = room.transform.position;
            GameObject.Find("Player1").transform.position = player1_pos.transform.position;
            GameObject.Find("Player1").GetComponent<PlayerController>().spawnPoint = player1_pos;
            if (GameObject.Find("Player2")) // prevent error messages in consol
            {
                GameObject.Find("Player2").transform.position = player2_pos.transform.position;
                GameObject.Find("Player2").GetComponent<PlayerController>().spawnPoint = player2_pos;
            }
        }
        else if (ChangeLevel)
        {
            audioManager.PlayNextLevelSound();
            SceneManager.LoadScene(levelToLoad);
        }
    }
}

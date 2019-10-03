using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    public GameObject room;
    public GameObject player1_pos;
    //public GameObject player2_pos;
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerController>())
        {
            StartCoroutine(LoadRoom());
        }
    }

    IEnumerator LoadRoom()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Main Camera").transform.position = room.transform.position;
        GameObject.Find("man1").transform.position = player1_pos.transform.position;
      // GameObject.Find("man2").transform.position = player2_pos.transform.position;
        //SceneManager.LoadScene(SceneName);
    }
}

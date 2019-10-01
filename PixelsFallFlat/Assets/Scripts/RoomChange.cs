using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    public GameObject room;
    // Start is called before the first frame update

        void OnTriggerEnter2D(Collider2D other)
        {
        if (other.gameObject.name == "Player1" || other.gameObject.name == "Player2")
        {
            StartCoroutine(LoadRoom());
        }
        }

    IEnumerator LoadRoom()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject.Find("Main Camera").transform.position = room.transform.position;
        //SceneManager.LoadScene(SceneName);
    }
}

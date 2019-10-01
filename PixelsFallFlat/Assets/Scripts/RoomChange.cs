using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomChange : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update

        void OnTriggerEnter2D(Collider2D other)
        {
        if (other.CompareTag("Movable"))
        {
            StartCoroutine(LoadScene());
        }
        }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneName);
    }
}

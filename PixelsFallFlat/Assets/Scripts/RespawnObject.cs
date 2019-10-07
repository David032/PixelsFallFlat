using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public GameObject spawnPoint;
    bool dead = false;

    public void Respawn()
    {
        Debug.Log("spawned");
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Void" && transform.parent == null)
        {
            Debug.Log("dead");
            if (!dead)
            {
                StartCoroutine(RespawnCountDown(2.0f));
            }
        }
    }

    IEnumerator RespawnCountDown(float waitTime)
    {
        Debug.Log("respawning");
        dead = true;
        this.gameObject.transform.localScale.Scale(new Vector3(0.5f, 0.5f)); //Trying to scale the player down as they fall
        yield return new WaitForSeconds(waitTime);
        Respawn();
    }
}

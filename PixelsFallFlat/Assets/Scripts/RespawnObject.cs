using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    public GameObject spawnPoint;

    public void Respawn()
    {
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "void" && transform.parent == null)
        {
            RespawnCountDown(2.0f);
        }
    }

    IEnumerable RespawnCountDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Respawn();
    }
}

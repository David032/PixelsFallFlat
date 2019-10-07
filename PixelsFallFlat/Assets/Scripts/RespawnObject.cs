using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{
    GameObject spawnPoint;
    bool dead = false;

    private void Start()
    {
        spawnPoint = new GameObject();
        spawnPoint.transform.position = transform.position;
        spawnPoint.transform.rotation = transform.rotation;        
    }

    public void Respawn()
    {
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;

        StartCoroutine(SpawnFall(0.75f));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Void" && transform.parent == null)
        {
            if (!dead)
            {
                StartCoroutine(DeathFall(0.75f));
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Void" && transform.parent == null)
        {
            if (!dead)
            {
                StartCoroutine(DeathFall(0.75f));
            }
        }
    }

    IEnumerator DeathFall(float waitTime)
    {
        dead = true;
        yield return new WaitForSeconds(waitTime / 2);
        this.gameObject.transform.localScale = new Vector3(0.75f, 0.75f);
        yield return new WaitForSeconds(waitTime);
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f);
        yield return new WaitForSeconds(waitTime);
        this.gameObject.transform.localScale = new Vector3(0.0f, 0.0f);
        yield return new WaitForSeconds(waitTime);
        Respawn();
    }

    IEnumerator SpawnFall(float waitTime)
    {
        this.gameObject.transform.localScale = new Vector3(1.33f, 1.33f);
        yield return new WaitForSeconds(waitTime);
        transform.localScale = new Vector3(1.0f, 1.0f);
        dead = false;
    }
}

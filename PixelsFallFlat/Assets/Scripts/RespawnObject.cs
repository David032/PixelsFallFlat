using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{

    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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

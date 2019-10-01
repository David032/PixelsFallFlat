using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWBoulder : MonoBehaviour
{
    public Transform spawnPos;

    public GameObject boulder;
    public GameObject hammer;
    public GameObject rock1;
    public GameObject rock2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == hammer)
        {
            //Destroy(boulder.gameObject);
            //Destroy(this.gameObject);
            //Instantiate(rock1, spawnPos.position, spawnPos.rotation);
            //Instantiate(rock2, spawnPos.position, spawnPos.rotation);
        }
    }
}
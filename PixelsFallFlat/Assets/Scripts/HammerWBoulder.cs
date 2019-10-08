using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWBoulder : MonoBehaviour
{
 
    public GameObject boulder;
    public GameObject hammer;
    public GameObject rock1;
    public GameObject rock2;

    public WorldSounds audioManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == hammer || collision.gameObject.name == "hammer(Clone)")
        {
            Instantiate(rock1, transform.position + new Vector3(-0.1f , 0f, 0f ), new Quaternion());
            Instantiate(rock2, transform.position + new Vector3(0.1f, 0f, 0f), new Quaternion());
            audioManager.PlayBreakingSound();
            Destroy(this.gameObject);
        }
    }
}
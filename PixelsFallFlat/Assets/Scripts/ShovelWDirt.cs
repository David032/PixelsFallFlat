using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelWDirt : MonoBehaviour
{

    public GameObject dirtHill;
    public GameObject shovel;
    public GameObject hiddenItem;

    public WorldSounds audioManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == shovel || collision.gameObject.name == "shovel(Clone)")
        {
            Instantiate(hiddenItem, transform.position + new Vector3(0f, 0f, 0f), new Quaternion());
            audioManager.PlayShovelSound();
            Destroy(this.gameObject);
        }
    }
}
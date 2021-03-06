﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWTree : MonoBehaviour
{ 

    public GameObject tree;
    public GameObject axe;
    public GameObject trunk;
    public GameObject[] voidTiles;

    public WorldSounds audioManager;

    void FixedUpdate()
    {
        axe = GameObject.Find("axe");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "axe(Clone)" ||collision.gameObject == axe)
        {
            audioManager.PlayAxeSound();
            Instantiate(trunk, transform.position + new Vector3(0.3f, 0f, 0f), new Quaternion());
            foreach(GameObject tile in voidTiles)
            {
                tile.GetComponent<BoxCollider2D>().enabled = false;
            }
            audioManager.PlayTreeSound();
            Destroy(this.gameObject);
        }
    }
}

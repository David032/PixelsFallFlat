﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWKey : MonoBehaviour
{
    public Transform spawnPos;

    public GameObject keyLock;
    public GameObject key;
    public GameObject keyLockWithKey;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Key")
        //{

        //}
        if (collision.gameObject == key)
        {
            //Locked Door open
            //Destroy(keyLock.gameObject);
            //Destroy(this.gameObject);
            //Instantiate(keyLockWithKey, spawnPos.position, spawnPos.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWKey : MonoBehaviour
{
 

    public GameObject keyLock;
    public GameObject key;
    public Sprite keyLockWithKey;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Key")
        //{

        //}
        if (collision.gameObject == key)
        {
            //Locked Door open
            Destroy(key.gameObject);
            //Destroy(this.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = keyLockWithKey;
        }
    }
}


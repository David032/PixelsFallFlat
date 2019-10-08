using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockWKey : MonoBehaviour
{
 

    public GameObject keyLock;
    public GameObject key;
    public Sprite keyLockWithKey;

    public WorldSounds audioManager;
    public bool doorIsOpen;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Key")
        //{

        //}
        if (collision.gameObject == key || collision.gameObject.name == "key(Clone)")
        {
            //Locked Door open
            Destroy(collision.gameObject);
            audioManager.PlayUnlockSound();
            //Destroy(this.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = keyLockWithKey;
            doorIsOpen = true;
        }
    }
}


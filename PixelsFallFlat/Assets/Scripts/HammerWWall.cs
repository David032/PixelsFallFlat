using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWWall : MonoBehaviour
{
    public GameObject hammer;
    public Sprite door;
    public BoxCollider2D passage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == hammer || collision.gameObject.name == "hammer(Clone)")
        {
            this.GetComponent<SpriteRenderer>().sprite = door;
            passage.enabled = true;
        }
    }
}

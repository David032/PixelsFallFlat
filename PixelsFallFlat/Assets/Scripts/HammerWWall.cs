using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerWWall : MonoBehaviour
{
    public GameObject hammer;
    public Sprite door;

    public WorldSounds audioManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == hammer || collision.gameObject.name == "hammer(Clone)")
        {
            this.GetComponent<SpriteRenderer>().sprite = door;
            audioManager.PlayBreakingSound();
            GetComponent<RoomChange>().canMove = true;
            GetComponent<BoxCollider2D>().offset = new Vector2(0.0f, 0.034f);
            GetComponent<BoxCollider2D>().size = new Vector2(0.2f, 0.0123f);
        }
    }
}

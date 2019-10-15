using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInteraction : MonoBehaviour
{
    public PipeHandler.PipeSize TargetSize = PipeHandler.PipeSize.Full;
    public float TargetRotation = 0f;

    public WorldSounds audioManager;

    public bool pipeComplete = false;

    public SpriteRenderer sprite;

    void start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PipeHandler>().Pipe == TargetSize)
        {
            audioManager.PlayPipeplaceSound();
            pipeComplete = true;
            collision.gameObject.tag.Replace(collision.gameObject.tag, null);
            collision.gameObject.SetActive(false);
            sprite.enabled = true;
        }
    }
}

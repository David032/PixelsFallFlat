using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInteraction : MonoBehaviour
{
    public PipeHandler.PipeSize TargetSize = PipeHandler.PipeSize.Full;
    public float TargetRotation = 0f;

    public bool pipeComplete = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PipeHandler>().Pipe == TargetSize)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().rotation = TargetRotation;
            collision.gameObject.GetComponent<Transform>().rotation.eulerAngles.Set(0f, 0f, TargetRotation);
            collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;

            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.transform.position = this.transform.position;
            collision.gameObject.GetComponent<Transform>().rotation.eulerAngles.Set(0f, 0f, TargetRotation);
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            pipeComplete = true;
            collision.gameObject.tag.Replace(collision.gameObject.tag, null);
        }
    }
}

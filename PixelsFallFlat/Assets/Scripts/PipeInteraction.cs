using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeInteraction : MonoBehaviour
{
    public PipeHandler.PipeSize TargetSize = PipeHandler.PipeSize.Full;
    public float TargetRotation = 0f;

    public bool pipeComplete = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PipeHandler>().Pipe == TargetSize)
        {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.transform.position = this.transform.position;
            collision.gameObject.GetComponent<Transform>().rotation.eulerAngles.Set(0f,0f,TargetRotation);
            collision.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            pipeComplete = true;
            collision.tag.Replace(collision.tag, null);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    public bool IsActive = false;

    void crateHandler(Collider2D collision) 
    {
        if (collision.gameObject.GetComponent<CrateHandler>())
        {
            IsActive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        crateHandler(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        crateHandler(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsActive = false;
    }
}

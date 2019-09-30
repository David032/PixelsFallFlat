using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite basePlayer;
    public Sprite armedPlayer;

    Rigidbody2D playerBody;
    bool armsOut = false;
    public float speed = 2;
    GameObject grabbed;

    private Vector2 playerVelocity;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = basePlayer;
        GetComponent<BoxCollider2D>().enabled = false;
        
        playerBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");        

        Vector2 direction = new Vector2(h, v);

        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle * -1, Vector3.forward);
        }


        playerVelocity = direction.normalized * speed;

        playerBody.MovePosition(playerBody.position + playerVelocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        ArmControl();

        if (armsOut)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (!armsOut)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void ArmControl() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<SpriteRenderer>().sprite = armedPlayer;
            armsOut = true;
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<SpriteRenderer>().sprite = basePlayer;
            armsOut = false;
            grabbed.transform.SetParent(null);
            grabbed.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbed = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Movable")
        {
            collision.transform.SetParent(this.transform);
            collision.transform.GetComponent<Rigidbody2D>().isKinematic = true;
            grabbed = collision.gameObject;
        }
    }
}

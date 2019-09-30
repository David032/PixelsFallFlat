using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum Player
    {
        Player1,
        Player2
    }
    
    public Sprite basePlayer;
    public Sprite armedPlayer;
    public Player thisPlayer = Player.Player1;

    Rigidbody2D playerBody;
    bool armsOut = false;
    public float speed = 2;
    GameObject grabbed;
    Vector2 playerVelocity;

    string hAxis = "Horizontal";
    string vAxis = "Vertical";

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = basePlayer;
        GetComponent<BoxCollider2D>().enabled = false;
        
        playerBody = GetComponent<Rigidbody2D>();

        if (thisPlayer == Player.Player2)
        {
            hAxis = "P2Horizontal";
            vAxis = "P2Vertical";
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis(hAxis);
        float v = Input.GetAxis(vAxis);        

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
        switch (thisPlayer)
        {
            case Player.Player1:
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
                break;
            case Player.Player2:
                if (Input.GetButtonDown("P2Grab"))
                {
                    GetComponent<SpriteRenderer>().sprite = armedPlayer;
                    armsOut = true;
                }
                else if (Input.GetButtonUp("P2Grab"))
                {
                    GetComponent<SpriteRenderer>().sprite = basePlayer;
                    armsOut = false;
                    grabbed.transform.SetParent(null);
                    grabbed.GetComponent<Rigidbody2D>().isKinematic = false;
                    grabbed = null;
                }
                break;
           
            default:
                break;
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

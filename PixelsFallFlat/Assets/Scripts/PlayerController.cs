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
    public GameObject spawnPoint;

    Rigidbody2D playerBody;
    public float speed = 0;
    public Vector2 playerVelocity;

    string hAxis = "Horizontal";
    string vAxis = "Vertical";

    bool armsOut = false;
    GameObject grabbed = null;
    Vector2 grabbedPosition;

    float pWeight = 0.0f;

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

        pWeight = GetComponent<Rigidbody2D>().mass;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis(hAxis);
        float v = Input.GetAxis(vAxis);
        speed = pWeight / GetComponent<Rigidbody2D>().mass;

        Vector2 direction = new Vector2(h, v);

        if (direction != Vector2.zero) ///Add '&& grabbed == null' here to disable rotation whilst holding an object, trying to work out how to give better rotation
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
                    grabbed.GetComponent<Rigidbody2D>().velocity.Set(0, 0);
                    grabbed.GetComponent<Rigidbody2D>().angularVelocity = 0;
                }
                else if (Input.GetButtonUp("Fire1"))
                {
                    GetComponent<SpriteRenderer>().sprite = basePlayer;
                    armsOut = false;
                    GetComponent<Rigidbody2D>().mass = pWeight;
                    grabbed.transform.SetParent(null);
                    grabbed.transform.GetComponent<Rigidbody2D>().useFullKinematicContacts = false;
                    grabbed.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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
                    GetComponent<Rigidbody2D>().mass = pWeight;
                    if (grabbed)
                    {
                        grabbed.transform.SetParent(null);
                        grabbed.transform.GetComponent<Rigidbody2D>().useFullKinematicContacts = false;
                        grabbed.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                        grabbed = null;
                    }
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

            collision.transform.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
            grabbed = collision.gameObject;
            GetComponent<Rigidbody2D>().mass += collision.GetComponent<Rigidbody2D>().mass;
            grabbedPosition = grabbed.GetComponent<Rigidbody2D>().position;
            grabbed.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        }

        if (collision.gameObject.tag == "Void")
        {
            speed = 0;
            Debug.Log("dead");
            StartCoroutine_Auto(RespawnCountDown(2.0f));
        }
    }
    void Respawn()
    {
        Debug.Log("respawn");
        if (grabbed != null)
        {
            grabbed.transform.SetParent(null);
            grabbed.transform.GetComponent<Rigidbody2D>().useFullKinematicContacts = false;
            grabbed.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbed.GetComponent<RespawnObject>().Respawn();
            grabbed = null;
        }
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        speed = 1;
        //speed = baseSpeed;
    }

    IEnumerator RespawnCountDown(float waitTime)
    {
        Debug.Log("respawning");
        yield return new WaitForSeconds(waitTime);
        Respawn();
    }
}

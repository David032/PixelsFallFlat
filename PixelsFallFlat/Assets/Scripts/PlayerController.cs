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

    string hAxis = "P1Horizontal";
    string vAxis = "P1Vertical";

    bool armsOut = false;
    GameObject grabbed = null;
    Vector2 grabbedPosition;

    float pWeight = 0.0f;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = basePlayer;
        GetComponent<CapsuleCollider2D>().enabled = false;

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
            //transform.rotation = Quaternion.AngleAxis(angle * -1, Vector3.forward); - Old rotation, might not be as snappy
            transform.rotation.eulerAngles.Set(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, angle * -1);
        }

        playerVelocity = direction.normalized * speed;
        Vector2 pos = playerBody.position + playerVelocity * Time.fixedDeltaTime;
        playerBody.MovePosition(pos);
    }

    void Update()
    {
        ArmControl();

        if (armsOut)
        {
            GetComponent<CapsuleCollider2D>().enabled = true;
            //GetComponent<BoxCollider2D>().offset = new Vector2(0,-0.005f); - Disabled due to physics bugs
            //GetComponent<BoxCollider2D>().size = new Vector2(0.14f, 0.13f);- Disabled due to physics bugs
        }
        else if (!armsOut)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            //GetComponent<BoxCollider2D>().offset = new Vector2(0f,-0.038f);- Disabled due to physics bugs
            //GetComponent<BoxCollider2D>().size = new Vector2(0.14f,0.065f);- Disabled due to physics bugs
        }
    }

    void ArmControl() 
    {
        switch (thisPlayer)
        {
            case Player.Player1:
                if (Input.GetButtonDown("P1Grab"))
                {
                    GetComponent<SpriteRenderer>().sprite = armedPlayer;
                    armsOut = true;
                }
                else if (Input.GetButtonUp("P1Grab"))
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
            if (grabbed == null)
            {
                grabbed = collision.gameObject;
                collision.transform.SetParent(this.transform);

                GetComponent<Rigidbody2D>().mass += collision.GetComponent<Rigidbody2D>().mass;
                grabbedPosition = grabbed.GetComponent<Rigidbody2D>().position;

                grabbed.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabbed.GetComponent<Rigidbody2D>().useFullKinematicContacts = true;
                grabbed.GetComponent<Rigidbody2D>().velocity.Set(0, 0);
                grabbed.GetComponent<Rigidbody2D>().angularVelocity = 0;

                GetComponent<Rigidbody2D>().velocity.Set(0, 0);
                GetComponent<Rigidbody2D>().angularVelocity = 0;
            }
        }

        if (collision.gameObject.tag == "Void")
        {

            speed = 0;

            Debug.Log("dead");

            StartCoroutine(RespawnCountDown(2.0f));

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
    }

    IEnumerator RespawnCountDown(float waitTime)
    {
        Debug.Log("respawning");
        this.gameObject.transform.localScale.Scale(new Vector3(0.5f, 0.5f)); //Trying to scale the player down as they fall
        yield return new WaitForSeconds(waitTime);
        Respawn();
    }
}

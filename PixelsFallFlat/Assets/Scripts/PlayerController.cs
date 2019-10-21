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

    string hAxis;
    string vAxis;

    bool armsOut = false;
    bool dead = false;
    GameObject grabbed = null;
    Vector2 grabbedPosition;

    float pWeight = 0.0f;

    public WorldSounds audioManager;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = basePlayer;
        GetComponent<CapsuleCollider2D>().enabled = false;

        playerBody = GetComponent<Rigidbody2D>();

        hAxis = thisPlayer + "Horizontal";
        vAxis = thisPlayer + "Vertical";

        pWeight = GetComponent<Rigidbody2D>().mass;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis(hAxis);
        float v = Input.GetAxis(vAxis);
        if (dead)
        { return; }

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
        }
        else if (!armsOut)
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }

    void ArmControl() 
    {

        if (Input.GetButtonDown(thisPlayer + "Grab"))
        {
            GetComponent<SpriteRenderer>().sprite = armedPlayer;
            armsOut = true;
        }
        else if (Input.GetButtonUp(thisPlayer + "Grab"))
        {
            GetComponent<SpriteRenderer>().sprite = basePlayer;
            armsOut = false;
            GetComponent<Rigidbody2D>().mass = pWeight;

            if (grabbed && !dead)
            {
                DropItem();
            }       
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

            if (!dead)
            {
                StartCoroutine(RespawnCountDown(0.75f));
            }
        }

    }
    void Respawn()
    {
        dead = false;
        transform.localScale = new Vector3(1.0f, 1.0f);
        speed = 1;
    }

    IEnumerator RespawnCountDown(float waitTime)
    {
        dead = true;
        yield return new WaitForSeconds(waitTime/2);
        this.gameObject.transform.localScale = new Vector3(0.75f, 0.75f);
        yield return new WaitForSeconds(waitTime);
        this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f);
        yield return new WaitForSeconds(waitTime);
        this.gameObject.transform.localScale = new Vector3(0.0f, 0.0f);
        switch (thisPlayer)
        {
            case Player.Player1:
                audioManager.PlayDeath1Sound();
                break;
            case Player.Player2:
                audioManager.PlayDeath2Sound();
                break;
        }

        yield return new WaitForSeconds(waitTime);

        if (grabbed != null)
        {
            grabbed.GetComponent<RespawnObject>().Respawn();
            DropItem();
        }
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        this.gameObject.transform.localScale = new Vector3(1.33f, 1.33f);
        audioManager.PlayRespawnSound();
        yield return new WaitForSeconds(waitTime);
        Respawn();
    }

    public void DropItem()
    {
        grabbed.transform.SetParent(null);
        grabbed.transform.GetComponent<Rigidbody2D>().useFullKinematicContacts = false;
        grabbed.GetComponent<Rigidbody2D>().isKinematic = false;
        grabbed = null;
    }
}

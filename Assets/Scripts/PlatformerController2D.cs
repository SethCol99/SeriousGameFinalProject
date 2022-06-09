using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController2D : MonoBehaviour
{
    public float life = 3;
    public float numJump = 5;
    public float up = 8;
    public float speed = 3;
    public bool ground = true;

    [Header("Grounding")]
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.1f;

    public LayerMask groundMask;

    Rigidbody2D rb2d;
    Rigidbody2D rb2d2;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3()
            Vector2 ver = rb2d2.velocity;

        bool onGround = Input.GetKeyDown(KeyCode.Space);
        UpdateGrounding();


        if (numJump > 0)
        {

            if (Input.GetKeyDown(KeyCode.Space) && ground)
            {
                ver = new Vector2(0, up);
                numJump--;
            }
        }
        
        rb2d2.velocity = ver;

        float horizInput = Input.GetAxis("Horizontal");
        Vector2 vel = rb2d.velocity;
        vel.x = horizInput * speed;
        rb2d.velocity = vel;
        //Debug.Log(horizInput);
    }

    public void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("coin"))
        {
            //obj.Destroy(obj, 2);
            numJump += 5;
            Destroy(obj.gameObject);
            Debug.Log("coin hit");
        }
        else if(obj.CompareTag("Spike"))
        {
            life--;

            if(life == 0)
            {
                Destroy(gameObject);
            }
        }

    }

    void UpdateGrounding()
    {

        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;

        RaycastHit2D contact = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D contactL = Physics2D.Raycast(rayStartLeft, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D contactR = Physics2D.Raycast(rayStartRight, Vector3.down, groundRayLength * 2, groundMask);

        Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * groundRayLength * 2, Color.red);
        Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * groundRayLength * 2, Color.red);

        if (contact.collider != null || contactL.collider != null || contactR.collider != null)
        {
            print("grounded");
            ground = true;
        }
        else
        {
            print("lifted");
            ground = false;
        }
    }

    }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonScript : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -9 || transform.position.x > 9)
        {
            speed *= -1;
          
            transform.Rotate(Vector3.forward * -180);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.gameObject.CompareTag("Driver"))
        {
           Destroy(GetComponent<SpriteRenderer>());
        }
    }
}

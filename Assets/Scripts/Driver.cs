using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Driver : MonoBehaviour
{

    public float horizontalSpeed = 3;
    public float speed = 1;
    public float peopleKilled = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        // if the other object has the asteroid tag, the destroy the ship and restard the game
        if (col.gameObject.CompareTag("Enemy"))
        {

            // load the active scene again, to restard the game. The GameManager will handle this for us. We use a slight delay to see the explosion.
            //StartCoroutine(RestartTheGameAfterSeconds(1));
            // we can not destroy the spaceship since it needs to run the coroutine to restart the game.
            // instead, disable update (isDead = true) and remove the renderer to "hide" the object while we reload.
            //isDead = true;
            peopleKilled++;
            Destroy(GetComponent<SpriteRenderer>());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

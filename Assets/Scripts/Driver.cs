using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Driver : MonoBehaviour
{

    public float horizontalSpeed = 3;
    public float speed = 1;
    public float peopleKilled = 0;

    public GameObject explosionPrefab;

    bool collided;
    bool timeUp;

    public int numExplosions;

    public Button resetButton;

    public bool playerDead;
    

    // Start is called before the first frame update
    void Start()
    {
        numExplosions = 0;
        collided = false;
        resetButton.gameObject.SetActive(false);
        timeUp = false;
        playerDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (transform.position.x >= 5.5 || transform.position.x <= -5.5)
        {
            horizontalSpeed = 0;
            speed = 0;
            if (numExplosions == 0)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(GetComponent<SpriteRenderer>());
            }
            numExplosions++;
            playerDead = true;
           
        }
        if (collided == true)
        {
            speed = 0;
           
        }
        if (playerDead)
        {
            resetButton.gameObject.SetActive(true);
        }
        else
        {
            resetButton.gameObject.SetActive(false);
        }

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
            collided = true;
            peopleKilled++;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(GetComponent<SpriteRenderer>());
            if (timeUp)
            {     
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            playerDead = true;
            
        }
        else if (col.gameObject.CompareTag("Person"))
        { 
            peopleKilled++;
                   
        }
    }

    void reloadScene()
    {

    }
}

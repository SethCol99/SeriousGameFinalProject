using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;


public class Driver : MonoBehaviour
{

    public float horizontalSpeed = 3;
    public float speed = 1;
    public float peopleKilled = 0;  

    public int numGens;
    public int numExplosions;
    public int dranks;
    int upperSteeringLimit;

    bool collided;
    bool timeUp;
    bool playerDead;
    bool victory;

    public GameObject explosionPrefab;
    public GameObject tombstone;
    public Button resetButton;
    public GameObject victoryPanel;
    public GameObject backgroundPanel;
    public Button playAgainButton;
    public Button quitButton;

    public CameraScript cam;
    
    public TMP_Text peopleKilledText;
    public TMP_Text finalMessage;

    private String[] messages = new String[] {
        "The cost of a taxi is always cheaper than a DUI",
        "It’s illegal to drink and drive in every US state",
        "30% of all traffic crash fatalities in the United States involve drunk drivers",
        "32 people die due to drinking and driving every day in the United States",
        "It only takes 2-3 drinks to reach the legal limit"
    };

    // Start is called before the first frame update
    void Start()
    {
        
        resetButton.gameObject.SetActive(false);
        victoryPanel.gameObject.SetActive(false);
        playAgainButton.gameObject.SetActive(false);
        finalMessage.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        backgroundPanel.gameObject.SetActive(false);

        timeUp = false;
        playerDead = false;
        numGens = 0;
        victory = false;
        numExplosions = 0;
        collided = false;


        upperSteeringLimit = dranks * 3;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            randomHorizontalVelocity();
        }
        
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
            horizontalSpeed = 0;
        }
        if (playerDead)
        {
            resetButton.gameObject.SetActive(true);
        }
        else
        {
            resetButton.gameObject.SetActive(false);
        }

        if (transform.position.y > cam.globalMaxY)
        {
            victory = true;
            speed = 0;
            horizontalSpeed = 0;

        }

        if (victory == true)
        {
            var rnd2 = new System.Random();

            victoryPanel.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
            finalMessage.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            backgroundPanel.gameObject.SetActive(true);

            if (numGens == 0)
            {
                finalMessage.text = messages[rnd2.Next(0, 4)];
            }
            numGens++;

            peopleKilledText.text = ((int)peopleKilled).ToString("D1");
            

        }

    }

    void randomHorizontalVelocity()
    {
        var rnd = new System.Random();

        horizontalSpeed = rnd.Next(1, upperSteeringLimit);
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
            Instantiate(tombstone, transform.position, Quaternion.identity);

        }
    }


}

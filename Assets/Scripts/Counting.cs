using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Counting : MonoBehaviour
{
    public static float numDrinks = 0;
    public Text drinkText;
    public Text prompt;
    public Animator anim;
    public bool animOn;
    void Start()
    {
        animOn = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    private void Update()
    {
        drinkText.text = (numDrinks).ToString();
    }

    public void StartDrinking(string start)
    {

        //anim.SetBool(start, true);
        //animOn = true;
        //print(anim);
        numDrinks++;
        //animOn = false;

        if(numDrinks > 2 && numDrinks < 15)
        {
            prompt.text = "Have a drink or head home";
        }

        else if(numDrinks == 15)
        {
            prompt.text = "You've reached your limit, time to head out";

            int i = 0;
            while(i < 10000)
            {
                i++;
                
            }
            SceneManager.LoadScene("Inside Car");
        }
    }
}

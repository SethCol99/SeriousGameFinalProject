using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrinkScript : MonoBehaviour
{
    public int numDrinks;
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        numDrinks = 4;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = ((int)numDrinks).ToString("D2");
    }

    public void increaseDrinks()
    {
        numDrinks++;
        if (numDrinks > 15)
        {
            numDrinks = 15;
        }
    }

    public void decreaseDrinks()
    {
        numDrinks--;
        if (numDrinks < 3)
        {
            numDrinks = 3;
        }
    }
}

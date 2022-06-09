using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class InsidePopUp : MonoBehaviour
{
    public Button cooldown;
    public bool coolingDown;
    public float waitTime = 1;
    public float waitTimeRatio = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        cooldown.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime > 0)
        {
            waitTime -= 1.0f / waitTimeRatio * Time.deltaTime;
            cooldown.gameObject.SetActive(true);
        }
        if(waitTime < 0)
        {
            cooldown.gameObject.SetActive(false);
        }
    }
}

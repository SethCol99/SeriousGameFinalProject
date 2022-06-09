using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InsideCarScript : MonoBehaviour
{

    public int digit = 1;
    public bool isDead;
    public bool isFinished;

    public Button resetButton;
    public Button nextLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        isFinished = false;
        resetButton.gameObject.SetActive(false);
        nextLevelButton.gameObject.SetActive(false);
    }

    public void buttonPressed(int i)
    {
        if(!isDead)
        {
            if (i == digit)
            {
                digit = i;
                if (i == 5)
                {
                    nextLevelButton.gameObject.SetActive(true);
                    isFinished = true;
                }
            }
            else if (!isFinished)
            {
                isDead = true;
            }
        }
        
        digit++;
    }



    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            resetButton.gameObject.SetActive(true);
        }
        else
        {
            resetButton.gameObject.SetActive(false);
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

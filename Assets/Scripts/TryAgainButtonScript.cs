using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainButtonScript : MonoBehaviour
{

    public Driver target;

    public Button resetButton;

    //// Start is called before the first frame update
    void Start()
    {
        resetButton.enabled = false;
    }

    //// Update is called once per frame
    void Update()
    {
        if (target.playerDead)
        {
            resetButton.enabled = true;
        }
        else
        {
            resetButton.enabled = false;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

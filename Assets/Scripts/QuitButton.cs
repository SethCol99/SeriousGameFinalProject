using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class QuitButton : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        print(name);
    }
}

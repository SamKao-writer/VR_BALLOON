using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scene : MonoBehaviour
{

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            SceneManager.LoadScene("Demo");
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            SceneManager.LoadScene("Demo_fast");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            SceneManager.LoadScene("Demo_triple");
        }
        
        if (Input.GetKeyUp(KeyCode.F))
        {
            SceneManager.LoadScene("Demo_fruit");
        }
        /*
        if (Input.GetKeyUp(KeyCode.A))
        {
            Application.Quit();
        }
        */
    }
}

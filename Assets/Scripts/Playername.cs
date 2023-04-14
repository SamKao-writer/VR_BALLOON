using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playername : MonoBehaviour
{
    //public string nameofplayer;
    //public string saveName;

    public static string playerpath;
    public Text inputText;
    //public Text loadedName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //nameofplayer = PlayerPrefs.GetString("name", "none");
        //loadedName.text = nameofplayer; 
    }

    public void SetName()
    {
        playerpath = inputText.text;
        SceneManager.LoadScene("ballon");
        //Second.SetActive(true);
        //Debug.Log(Record.playerpath);
        //saveName = inputText.text;
        //PlayerPrefs.SetString("name", saveName);
    }
}

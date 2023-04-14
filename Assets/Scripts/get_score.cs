using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class get_score : MonoBehaviour
{
    public GameManager _Game;
    //AudioSource audioData;
    float temp;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log("aaa");
        /*if (other.name == "Balloon_EX(Clone)" || other.name == "Balloon_third(Clone)" )
        {
            Debug.Log(other.name);
            audioData = GetComponent<AudioSource>(); // play the bomp voice
            audioData.Play(0);
            GameManager.instance.Getscore(1, 1);
        }
        else if (other.name == "Balloon_EX_black(Clone)" || other.name ==  "Banana(Clone)" )
        {
            //Debug.Log(other.name);
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            GameManager.instance.Getscore(1, 2);
        }*/

        //Destroy(other.gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mode : MonoBehaviour
{
    public GameObject static_mode, dynamic_mode; 
    // Start is called before the first frame update
    // void Start()
    // {
    //     if (Input.GetKeyUp(KeyCode.Alpha1)){
    //         // static_mode.GetComponent<GameObject>().SetActive=true;
    //         // static_mode.SetActive(true);
    //         print("AA");
    //     }

    //     if (Input.GetKeyUp(KeyCode.Alpha2)){
    //         print("BB");
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1)){
            // static_mode.GetComponent<GameObject>().SetActive=true;
            static_mode.SetActive(true);
            print("AA");
        }

        if (Input.GetKeyUp(KeyCode.Alpha2)){
            print("BB");
        }
    }
}

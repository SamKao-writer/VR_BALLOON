using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Vector3 v = new Vector3(354.0356f,13.19173f,10.10915f);
    // Vector3 v = new Vector3(0f,45f,45f);
    Vector3 v = new Vector3(356.9206f,7.547897f,358.6259f);
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v3 = (Quaternion.Euler(v) * Vector3.forward).normalized;
        Debug.Log(Quaternion.Euler(v));
        Debug.Log(Vector3.forward.x);
        Debug.Log(Vector3.forward.y);
        Debug.Log(Vector3.forward.z);
        Debug.Log(v3.x);
        Debug.Log(v3.y);
        Debug.Log(v3.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.forward);
    }
}

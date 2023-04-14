using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kill_plane : MonoBehaviour {
    //public GameManager _GameM;
    public AudioSource AudioData;
    public AudioClip[] otherClip;
    
    void Start()
    {
        AudioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {

        //GameManager.instance.Getscore(1);

        /*if (other.tag == "Floor")
        {
            //GameManager.instance.Getscore(1, 1);
            Destroy(gameObject);
        }*/
        if (other.tag == "red" || other.tag == "yellow")
        //else if (other.name == "Balloon_EX")
        {
            //GameManager.instance.Getscore(1, 1);
            //Debug.Log(this.gameObject);
            if(this.gameObject.tag != "Floor")
            {
                AudioData.clip = otherClip[0];
                AudioData.Play();
                GameManager.instance.Getscore(1, 1);
            }
            if(generator.check_des==1)
            {
                generator.check_des=0;
            }
            //other.GetComponent<Rigidbody>().useGravity=false;
            Destroy(other.gameObject);
        }
        else if (other.name == "Balloon_EX_black(Clone)")
        {
            //GameManager.instance.Getscore(1, 2);
            if(this.gameObject.tag != "Floor")
            {
                //AudioBlack = GetComponent<AudioSource>();
                AudioData.clip = otherClip[1];
                AudioData.Play();
                GameManager.instance.Getscore(1, 2);
            }
            Destroy(other.gameObject);
        }
        else if (other.name == "Balloon_third(Clone)")
        {
            //GameManager.instance.Getscore(1, 2);
            if(this.gameObject.tag != "Floor")
            {
                AudioData.clip = otherClip[2];
                AudioData.Play();
                GameManager.instance.Getscore(1, 2);
            }
            Destroy(other.gameObject);
        }
        else if (other.name == "Cube(Clone)")
        {
            //Debug.Log("aaa");
            Destroy(other.gameObject);
        }
        else if (other.name == "Sphere(Clone)")
        {
            //Debug.Log("aaa");
            Destroy(other.gameObject);
        }
        /*
        else if (other.name == "Banana(Clone)")
        {
            //GameManager.instance.Getscore(1, 2);
            Destroy(other.gameObject);
        }
        else if (other.name == "Apple(Clone)")
        {
            //GameManager.instance.Getscore(1, 2);
            Destroy(other.gameObject);
        }
        */

    }

}

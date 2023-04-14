using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class velocity : MonoBehaviour
{
    public static int num = 0;
    public static double avg = 0;
    public static double max = 0;
    Vector3 pos1 = new Vector3();
    Vector3 pos2 = new Vector3();
    public Rigidbody rb;
    public static int timer = 0, timer_i=0;
    public static int mode;
    string path;
    double x, y, z;
    public static double[] vel = new double[100000];
    int count = 0;
    Vector3 cam_rotation = new Vector3();
    Vector3 hand_rotation = new Vector3();

    public GameObject cam;
    
    Vector3 Get(Vector3 localpos)
    {
        return rb.GetPointVelocity(transform.TransformPoint(localpos));
    }


    void timer_4()
    {
        //Debug.Log(Get(GameObject.Find("RightHand").transform.position));
        //Debug.Log("aaa");
        //temp2 = temp1;
        //temp1 = Time.realtimeSinceStartup;
        double time = 0.01f;

        pos2 = pos1;
        pos1 = transform.position;
        Vector3 pos = pos1 - pos2;
        //Debug.Log(pos.x);
        double compute = (Math.Sqrt(pos.sqrMagnitude) ) / time; // velocity per 0.01 second
        compute *= 100; // convert to velocity per 1 second
        if(timer_i <= timer )
        {
            num++;
            if(compute > max && num >= 5)
            {
                max = compute;
            }
            avg += compute;

            switch (mode)
            {
                case 1:
                    path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\one_color.txt";
                    break;
                case 2:
                    path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\normal.txt";
                    break;
                case 3:
                    path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath +"\\faster.txt";
                    break;
                case 4:
                    path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\third.txt";
                    break;
                case 5:
                    path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\balloon_floor.txt";
                    break;
                default:
                    break;
            }

            x = transform.position.x;
            y = transform.position.y;
            z = transform.position.z;

            vel[count] = compute;
            count++;
            cam_rotation = cam.transform.rotation.eulerAngles;
            hand_rotation = transform.rotation.eulerAngles;
            //print(hand_rotation);
            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(compute + " " + "(" + x + "," + y + "," + z + ")" + " " + "(" + pos2.x + "," + pos2.y + "," + pos2.z + ")"
                             + " " + "(" + hand_rotation.x + "," + hand_rotation.y + "," + hand_rotation.z + ")"
                             + " " + "(" + cam.transform.position.x + "," + cam.transform.position.y + "," + cam.transform.position.z + ")" 
                             + " " + "(" + cam_rotation.x + "," + cam_rotation.y + "," + cam_rotation.z + ")");
            writer.Close();

            //print("compute " + compute);

        }
        else
        {
            this.CancelInvoke();
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            max = 0;
            avg = 0;
            num = 0;
            generator.square = 0;
            count = 0;


            CancelInvoke();
            //mode = 1;
            InvokeRepeating("timer_4", 0, .01f);

        }
        else if ( Input.GetKeyUp(KeyCode.S) )
        {
            max = 0;
            avg = 0;
            num = 0;
            generator.square = 0;
            count = 0;


            CancelInvoke();
            //mode = 2;
            InvokeRepeating("timer_4", 0, .01f);
            
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            max = 0;
            avg = 0;
            num = 0;
            generator.square = 0;
            count = 0;

            CancelInvoke();
            //mode = 3;
            InvokeRepeating("timer_4", 0, .01f);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            max = 0;
            avg = 0;
            num = 0;
            generator.square = 0;
            count = 0;

            CancelInvoke();
            //mode = 4;
            InvokeRepeating("timer_4", 0, .01f);
        }
    }



}

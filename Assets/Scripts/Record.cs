using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Record : MonoBehaviour
{
    string folderPath = Directory.GetCurrentDirectory() + "\\record_txt";

    // Start is called before the first frame update
    void Start()
    {
        folderPath = folderPath + "\\" + Playername.playerpath;
        if(!Directory.Exists(folderPath)){
            Directory.CreateDirectory(folderPath);
        }
        if(!File.Exists(folderPath+"\\head_record.txt")){
            File.Create(folderPath+"\\head_record.txt").Dispose();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            //CancelInvoke();
            InvokeRepeating("head_record", 0, .1f);
        }
    }

    void head_record()
    {
        if (velocity.timer_i <= velocity.timer)
        {
            //Debug.Log(transform.position);
            StreamWriter writer = new StreamWriter(folderPath+"\\head_record.txt", true);
            writer.WriteLine("(" + transform.position.x + "," + transform.position.y + "," + transform.position.z + ")");
            //writer.WriteLine(transform.position);
            writer.Close();
            
        }
        else if(velocity.timer_i == 65)
        {
            StreamWriter writer = new StreamWriter(folderPath+"\\head_record.txt", true);
            writer.WriteLine("0");
            writer.Close();
            this.CancelInvoke();
        }
    }
}

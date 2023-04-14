using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class balloon_pos : MonoBehaviour
{
    Vector3 balloon_start_pos = new Vector3();
    float balloon_start_time;
    Vector3 balloon_end_pos = new Vector3();
    float balloon_end_time;
    string path;
    public static int balloon_count;
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //print(Time.deltaTime);
        balloon_start_pos = this.transform.position;
        balloon_start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(rb.velocity.y);
        // Debug.Log(this.transform.position.y);
    }
   
    void OnDestroy()
    {
        balloon_count++;
        balloon_end_pos = this.transform.position;
        balloon_end_time = Time.time;
        if(velocity.mode == 1)
            path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\one_color_balloon_pos.txt";
        else if(velocity.mode == 2)
            path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\normal_balloon_pos.txt";
        else if(velocity.mode == 4)
            path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\third_balloon_pos.txt";
        else if(velocity.mode == 5)
            path = Directory.GetCurrentDirectory() + "\\record_txt" + "\\" + Playername.playerpath + "\\balloon_floor_balloon_pos.txt";

        StreamWriter writer = new StreamWriter(path, true);
        //color, start time, end time, drag, start position, end position
        writer.WriteLine(this.tag + " " + balloon_start_time + " " + balloon_end_time + " " + this.GetComponent<Rigidbody>().drag + " " +"(" + balloon_start_pos.x + "," + balloon_start_pos.y + "," + balloon_start_pos.z + ")" + " " + "(" + balloon_end_pos.x + "," + balloon_end_pos.y + "," + balloon_end_pos.z + ")");

        if(balloon_count==40 && velocity.mode == 1)
            writer.WriteLine("0");
        else if(balloon_count==60 && (velocity.mode == 2 || velocity.mode == 4))
            writer.WriteLine("0");
        else if(velocity.mode == 5)
            writer.WriteLine(balloon_count);
        writer.Close();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Threading;

public class generator : MonoBehaviour {
    //public static generator instance;
    // public static int timer_i = 0;
    public static int check_des=0;

    public static double square = 0;
    double std_dev;

    // Use this for initialization
    private GameObject temp_cube, temp_sphere, temp_red, temp_black, temp_third, temp_banana, temp_apple;
    public GameObject train_cube, train_sphere;
    public GameObject red, black, third;
    public GameObject banana, apple;
    public float radius=0.7f;
    public float x_shift=0.0f;
    public float z_shift=0.0f;
    double temp = 0;
    string folderPath = Directory.GetCurrentDirectory() + "\\record_txt";
    // int i=0;

    /*void Update(){
        if (Input.GetKeyUp(KeyCode.T)||Input.GetKeyUp(KeyCode.Y))
        {
            FindObjectOfType<GameManager>().Restart();
        }
    }*/

    void Start () {
        //Debug.Log(folderPath);
        folderPath = folderPath + "\\" + Playername.playerpath;
        red.GetComponent<Rigidbody>().useGravity=true;
        black.GetComponent<Rigidbody>().useGravity=true;
        third.GetComponent<Rigidbody>().useGravity=true;
        if(!Directory.Exists(folderPath)){
            Directory.CreateDirectory(folderPath);
        }
        if(!File.Exists(folderPath+"\\one_color.txt")){
            File.Create(folderPath+"\\one_color.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\normal.txt")){
            File.Create(folderPath+"\\normal.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\faster.txt")){
            File.Create(folderPath+"\\faster.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\third.txt")){
            File.Create(folderPath+"\\third.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\balloon_floor.txt")){
            File.Create(folderPath+"\\balloon_floor.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\one_color_balloon_pos.txt")){
            File.Create(folderPath+"\\one_color_balloon_pos.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\normal_balloon_pos.txt")){
            File.Create(folderPath+"\\normal_balloon_pos.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\balloon_floor_balloon_pos.txt")){
            File.Create(folderPath+"\\balloon_floor_balloon_pos.txt").Dispose();
        }
        if(!File.Exists(folderPath+"\\third_balloon_pos.txt")){
            File.Create(folderPath+"\\third_balloon_pos.txt").Dispose();
        }
    }

    void Update () {
        // Press "T" to display cube training scene
        if (Input.GetKeyUp(KeyCode.T))
        {   
            float x_train_cube = UnityEngine.Random.Range(0.5f, 0.5f);
            temp_cube = Instantiate(train_cube, new Vector3(x_train_cube, 1, 0.5f), Quaternion.identity);

            x_train_cube = UnityEngine.Random.Range(-0.8f, -0.8f);
            temp_cube = Instantiate(train_cube, new Vector3(x_train_cube, 2f, 0.5f), Quaternion.identity);

            x_train_cube = UnityEngine.Random.Range(0.2f, 0.2f);
            temp_cube = Instantiate(train_cube, new Vector3(x_train_cube, 1.5f, 0.7f), Quaternion.identity);

            x_train_cube = UnityEngine.Random.Range(0.0f, 0.0f);
            temp_cube = Instantiate(train_cube, new Vector3(x_train_cube, 1, 1f), Quaternion.identity);

            x_train_cube = UnityEngine.Random.Range(-0.8f, -0.8f);
            temp_cube = Instantiate(train_cube, new Vector3(x_train_cube, 1.5f, 1f), Quaternion.identity);

            //temp_cube = Instantiate(train_cube, new Vector3(0.0f, 1, 0.0f), Quaternion.identity);
        }

        // Press "Y" to display sphere training scene
        if (Input.GetKeyUp(KeyCode.Y))
        {
            //FindObjectOfType<GameManager>().Restart();
            float x_train_sphere = UnityEngine.Random.Range(0.5f, 0.5f);
            temp_cube = Instantiate(train_sphere, new Vector3(x_train_sphere, 1.6f, 0.7f), Quaternion.identity);

            x_train_sphere = UnityEngine.Random.Range(-0.1f, -0.1f);
            temp_cube = Instantiate(train_sphere, new Vector3(x_train_sphere, 1.7f, 0.4f), Quaternion.identity);

            x_train_sphere = UnityEngine.Random.Range(0.1f, 0.1f);
            temp_cube = Instantiate(train_sphere, new Vector3(x_train_sphere, 1f, 0.3f), Quaternion.identity);

            x_train_sphere = UnityEngine.Random.Range(-0.1f, -0.1f);
            temp_cube = Instantiate(train_sphere, new Vector3(x_train_sphere, 0.5f, 0.5f), Quaternion.identity);

            x_train_sphere = UnityEngine.Random.Range(1f, 1f);
            temp_cube = Instantiate(train_sphere, new Vector3(x_train_sphere, 1.5f, 1f), Quaternion.identity);
        }


        //InvokeRepeating(a,b,c) -> Invokes the method "a" in "b" seconds, then repeatedly every "c" seconds.

        if (Input.GetKeyUp(KeyCode.A))
        {
            velocity.timer_i=0;
            velocity.timer = 60;
            velocity.mode = 1;
            balloon_pos.balloon_count = 0;
            InvokeRepeating("timer_one_color", 0, .5f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            velocity.timer_i=0;
            velocity.timer = 55;
            velocity.mode = 2;
            balloon_pos.balloon_count = 0;
            InvokeRepeating("timer_0", 0, .5f);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            velocity.timer_i=0;
            // velocity.timer = 50;
            velocity.timer = 55;
            velocity.mode = 4;
            balloon_pos.balloon_count = 0;
            InvokeRepeating("timer_third", 0, .5f);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            velocity.timer_i=0;
            velocity.timer = 60;
            velocity.mode = 5;
            balloon_pos.balloon_count = 0;
            InvokeRepeating("balloon_floor", 0, .5f);
            
            //velocity.timer = 40;
            //velocity.mode = 3;
            //InvokeRepeating("timer_faster", 0, .5f);
        }
        
        
        if (Input.GetKeyUp(KeyCode.G))
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }

    void timer_one_color()
    {
        // i++;
        velocity.timer_i += 1;
        // print(velocity.timer_i);
        // Debug.Log(Time.time);
        // Debug.Log(i);
        if (velocity.timer_i <= 40)
        {
            //Debug.Log(timer_i);
            float x_red = UnityEngine.Random.Range(-1f, 1f);
            //float z_red = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_red = UnityEngine.Random.Range(13.0f, 17.0f);
            red.GetComponent<Rigidbody>().drag = drag_red;
            temp_red = Instantiate(red, new Vector3(x_red, 5, 0.7f), Quaternion.identity);
        }
        else if (velocity.timer_i == 65)
        {
            //string path = "C:/Users/user/Desktop/record_txt/one_color.txt";
            //print(velocity.num);]
            print("timer_one_color");
            temp = velocity.avg / velocity.num;

            for (int i = 0; i < velocity.num; i++)
            {
                square += (velocity.vel[i] - temp) * (velocity.vel[i] - temp);
            }

            std_dev = Math.Sqrt(square / (velocity.num - 1));

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(folderPath+"\\one_color.txt", true);
            writer.WriteLine("Average= " + temp);
            writer.WriteLine("Max= " + velocity.max);
            writer.WriteLine("Standard Deviation= " + std_dev);
            writer.WriteLine("Right: " + GameManager.gameScore_right + "    Miss: " + (40-GameManager.gameScore_right) );
            writer.WriteLine("0");
            writer.Close();

            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);
            this.CancelInvoke();

        }

    }

    void timer_0()
    {
        velocity.timer_i += 1;

        if (velocity.timer_i <= 30)
        {
            float x_red = UnityEngine.Random.Range(-1f, 1f);
            //float z_red = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_red = UnityEngine.Random.Range(13.0f, 17.0f);
            red.GetComponent<Rigidbody>().drag = drag_red;
            temp_red = Instantiate(red, new Vector3(x_red, 5, 0.7f), Quaternion.identity);

            float x_black = UnityEngine.Random.Range(-1f, 1f);
            //float z_black = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_black = UnityEngine.Random.Range(10.0f, 20.0f);
            black.GetComponent<Rigidbody>().drag = drag_black;
            temp_black = Instantiate(black, new Vector3(x_black, 5, 0.7f), Quaternion.identity);
        }
        else if (velocity.timer_i == 60)
        {
            //print(velocity.num);
            print("timer_0");
            temp = velocity.avg / velocity.num;

            for (int i = 0; i < velocity.num; i++)
            {
                square += (velocity.vel[i] - temp) * (velocity.vel[i] - temp);
            }

            std_dev = Math.Sqrt(square / (velocity.num - 1));

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(folderPath+"\\normal.txt", true);
            writer.WriteLine("Average= " + temp);
            writer.WriteLine("Max= " + velocity.max);
            writer.WriteLine("Standard Deviation= " + std_dev);
            writer.WriteLine("Right: " + GameManager.gameScore_right + "    Wrong: " + GameManager.gameScore_wrong);
            writer.WriteLine("0");
            writer.Close();
            
            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);
            this.CancelInvoke();

        }
        
    }

    
    void timer_faster()
    {
        velocity.timer_i += 1;

        if (velocity.timer_i <= 30)
        {
            float x_red = UnityEngine.Random.Range(-1f, 1f);
            //float z_red = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_red = UnityEngine.Random.Range(7.0f, 11.0f);
            red.GetComponent<Rigidbody>().drag = drag_red;
            temp_red = Instantiate(red, new Vector3(x_red, 5, 0.7f), Quaternion.identity);

            float x_black = UnityEngine.Random.Range(-1f, 1f);
            //float z_black = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_sphere = UnityEngine.Random.Range(4.0f, 11.0f);
            black.GetComponent<Rigidbody>().drag = drag_sphere;
            temp_sphere = Instantiate(black, new Vector3(x_black, 5, 0.7f), Quaternion.identity);
            
        }
        else if (velocity.timer_i == 45)
        {
            //print(velocity.num);
            print("timer_faster");
            temp = velocity.avg / velocity.num;

            for (int i = 0; i < velocity.num; i++)
            {
                square += (velocity.vel[i] - temp) * (velocity.vel[i] - temp);
            }

            std_dev = Math.Sqrt(square / (velocity.num - 1));

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(folderPath+"\\faster.txt", true);
            writer.WriteLine("Average= " + temp);
            writer.WriteLine("Max= " + velocity.max);
            writer.WriteLine("Standard Deviation= " + std_dev);
            writer.WriteLine("Right: " + GameManager.gameScore_right + "    Wrong: " + GameManager.gameScore_wrong);
            writer.WriteLine("0");
            writer.Close();
            
            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);
            this.CancelInvoke();

        }

    }

    void timer_third()
    {
        velocity.timer_i += 1;
        if (velocity.timer_i <= 20)
        // if (velocity.timer_i <= 30)
        {
            float x_red = UnityEngine.Random.Range(-1f, 1f);
            //float z_red = UnityEngine.Random.Range(-0.5f, 0.5f);    
            float drag_red = UnityEngine.Random.Range(13.0f, 17.0f);
            red.GetComponent<Rigidbody>().drag = drag_red;
            temp_red = Instantiate(red, new Vector3(x_red, 5, 0.7f), Quaternion.identity);
            //var yellow_ball = temp_red.GetComponent<Renderer>();
            //yellow_ball.material.SetColor("_Color", Color.yellow);
            //yellow_ball.tag = "yellow";

            float x_black = UnityEngine.Random.Range(-1f, 1f);
            //float z_black = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_black = UnityEngine.Random.Range(10.0f, 20.0f);
            black.GetComponent<Rigidbody>().drag = drag_black;
            temp_black = Instantiate(black, new Vector3(x_black, 5, 0.7f), Quaternion.identity);
            //var purple_ball = temp_black.GetComponent<Renderer>();
            //Color purple = new Color(0.5f, 0, 0.65f, 0.9f);
            //purple_ball.material.SetColor("_Color", purple);
            //purple_ball.tag = "purple";

            float x_third = UnityEngine.Random.Range(-1f, 1f);
            //float z_third = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_third = UnityEngine.Random.Range(10.0f, 20.0f);
            third.GetComponent<Rigidbody>().drag = drag_third;
            temp_third = Instantiate(third, new Vector3(x_third, 5, 0.7f), Quaternion.identity);
            var white_ball = temp_third.GetComponent<Renderer>();
            white_ball.material.SetColor("_Color", Color.white);
            //white_ball.tag = "white";
            // if(velocity.timer_i%2==1)
            // {   
            //     var purple_ball = temp_third.GetComponent<Renderer>();
            //     Color purple = new Color(0.5f, 0, 0.65f, 0.9f);
            //     purple_ball.material.SetColor("_Color", purple);
            //     purple_ball.tag = "purple";   
            // }
            
        }
        else if (velocity.timer_i == 55)
        // else if (velocity.timer_i == 60)
        {
            //print(velocity.num);
            print("timer_third");
            // used to coupute standard deviation
            temp = velocity.avg / velocity.num;
            for (int i = 0; i < velocity.num; i++)
            {
                square += (velocity.vel[i] - temp) * (velocity.vel[i] - temp);
            }
            std_dev = Math.Sqrt(square / (velocity.num - 1));

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(folderPath+"\\third.txt", true);
            writer.WriteLine("Average= " + temp);
            writer.WriteLine("Max= " + velocity.max);
            writer.WriteLine("Standard Deviation= " + std_dev);
            writer.WriteLine("Right: " + GameManager.gameScore_right + "    Wrong: " + GameManager.gameScore_wrong);
            writer.WriteLine("0");
            writer.Close();

            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);
            this.CancelInvoke();

        }

    }

    void balloon_floor()
    {
        velocity.timer_i += 1;
        
        if (velocity.timer_i <= 55)
        {
            //Debug.Log("out");
            //if(!GameObject.Find("Balloon_EX"))
            if(check_des==0)//balloon is destroyed or not
            {
                //Debug.Log("in");
                red.GetComponent<Rigidbody>().useGravity=false;
                //float radius = UnityEngine.Random.Range(0.6f, 0.7f);
                float x_red = UnityEngine.Random.Range(-radius, radius);
                float z_red = Mathf.Sqrt(radius*radius-x_red*x_red);
                // = UnityEngine.Random.Range(0.0f, 1.0f);
                x_red = x_red + x_shift;
                z_red = z_red + z_shift;
                /*if(z_pos>0.5f)
                {
                    z_red =- z_red;
                }*/
                temp_red = Instantiate(red, new Vector3(x_red, 0.15f, z_red), Quaternion.identity);
                check_des = 1;
            }
            
            if (velocity.timer_i % 8 == 0){
                float drag_black = UnityEngine.Random.Range(70.0f, 80.0f);

                black.GetComponent<Rigidbody>().drag = drag_black;

                float x_black = UnityEngine.Random.Range(-radius, radius);
                float z_black = Mathf.Sqrt(radius*radius-x_black*x_black);

                x_black = x_black + x_shift;
                z_black = z_black + z_shift;
                temp_black = Instantiate(black, new Vector3(x_black, 0.15f, z_black), Quaternion.identity);
            }
        }
        else if (velocity.timer_i == 65)
        {
            red.GetComponent<Rigidbody>().useGravity=true;
            //print(velocity.num);
            print("balloon_floor");
            // used to coupute standard deviation
            temp = velocity.avg / velocity.num;
            for (int i = 0; i < velocity.num; i++)
            {
                square += (velocity.vel[i] - temp) * (velocity.vel[i] - temp);
            }
            std_dev = Math.Sqrt(square / (velocity.num - 1));

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(folderPath+"\\balloon_floor.txt", true);
            writer.WriteLine("Average= " + temp);
            writer.WriteLine("Max= " + velocity.max);
            writer.WriteLine("Standard Deviation= " + std_dev);
            writer.WriteLine("Right: " + GameManager.gameScore_right + "    Wrong: " + GameManager.gameScore_wrong);
            writer.WriteLine("0");
            writer.Close();

            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);
            this.CancelInvoke();

        }
    }

    /*
    void timer_fruit()
    {
        timer_i += 1;

        if (timer_i <= 30)
        {
            float x_cube = UnityEngine.Random.Range(-0.7f, 1.5f);
            float drag_cube = UnityEngine.Random.Range(13.0f, 17.0f);
            apple.GetComponent<Rigidbody>().drag = drag_cube;
            temp_apple = Instantiate(apple, new Vector3(x_cube, 5, -1.5f), Quaternion.identity);
            cube_count++;

            float x_sphere = UnityEngine.Random.Range(-0.7f, 1.5f);
            float drag_sphere = UnityEngine.Random.Range(10.0f, 20.0f);
            banana.GetComponent<Rigidbody>().drag = drag_sphere;
            temp_banana = Instantiate(banana, new Vector3(x_sphere, 5, -1.5f), Quaternion.identity);
            sphere_count++;
        }
        else if (timer_i >= 60)
        {

            temp = velocity.avg / velocity.num;
            print("average= " + temp);
            print("Max= " + velocity.max);


        }

    }
    */



    // Update is called once per frame
    /*
	void Update () {

        //UnityEngine.Random.Range(最小值, 最大值);
        //temp = Instantiate(cube, transform.position, Quaternion.identity);
        //temp.transform.position = new Vector3(5, 5, 5);

    }
    */


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Threading;

public class new_generator : MonoBehaviour
{
    //public static generator instance;
    // public static int timer_i = 0,count=0;

    public static double square = 0;
    double std_dev;

    // Use this for initialization
    private GameObject temp_cube, temp_sphere, temp_red, temp_black, temp_third, temp_banana, temp_apple;
    public GameObject train_cube, train_sphere;
    public GameObject red, black, third;
    public GameObject banana, apple;
    double temp = 0;
    string folderPath = Directory.GetCurrentDirectory() + "\\record_txt";

    // Start is called before the first frame update
    void Start()
    {
        red.GetComponent<Rigidbody>().useGravity=false;
        black.GetComponent<Rigidbody>().useGravity=false;
        third.GetComponent<Rigidbody>().useGravity=false;
        if(!Directory.Exists(folderPath)){
            Directory.CreateDirectory(folderPath);
        }
        if(!File.Exists(folderPath+"\\one_color.txt")){
            File.Create(folderPath+"\\one_color.txt");
        }
        if(!File.Exists(folderPath+"\\normal.txt")){
            File.Create(folderPath+"\\normal.txt");
        }
        if(!File.Exists(folderPath+"\\faster.txt")){
            File.Create(folderPath+"\\faster.txt");
        }
        if(!File.Exists(folderPath+"\\third.txt")){
            File.Create(folderPath+"\\third.txt");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            CancelInvoke();
            velocity.timer_i=0;
            velocity.timer = 65;
            InvokeRepeating("only_red", 0, 1.0f);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            CancelInvoke();
            velocity.timer_i=0;
            velocity.timer = 65;
            InvokeRepeating("two_color_red", 0, 1.0f);
            InvokeRepeating("two_color_black", 0, 1.5f);
        }
        /*if (Input.GetKeyUp(KeyCode.D))
        {
            CancelInvoke();
            timer_i = 0;
            InvokeRepeating("timer_faster", 0, .5f);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            CancelInvoke();
            timer_i = 0;
            InvokeRepeating("timer_third", 0, .5f);
        }*/
    }

    void only_red()
    {
        velocity.timer_i += 2;
        //Debug.Log(Time.time);
        if (velocity.timer_i <= 60)
        {
            //Debug.Log(timer_i);
            red_balloon();
        }
        else if (velocity.timer_i == 70)
        {
            record("\\one_color.txt");
        }
    }

    void two_color_red()
    {
        velocity.timer_i += 2;

        if (velocity.timer_i <= 60)
        {
            red_balloon();
        }
        else if (velocity.timer_i == 70)
        {
            record("\\normal.txt");
        }

    }

    void two_color_black()
    {
        if (velocity.timer_i <= 60)
        {
            black_balloon();
        }
    }

    void red_balloon()
    {
        float x_red = UnityEngine.Random.Range(-0.5f, 0.5f);
        float y_red = UnityEngine.Random.Range(0.5f, 1.5f);
        temp_red = Instantiate(red, new Vector3(x_red, y_red, 0.7f), Quaternion.identity);
        Destroy(temp_red,2.5f);
    }

    void black_balloon()
    {
        float x_black = UnityEngine.Random.Range(-0.5f, 0.5f);
        float y_black = UnityEngine.Random.Range(0.5f, 1.5f);
        temp_black = Instantiate(black, new Vector3(x_black, y_black, 0.7f), Quaternion.identity);
        Destroy(temp_black,2.0f);
    }

    void record(string file_name)
    {
        print(velocity.num);
        temp = velocity.avg / velocity.num;

            for (int i = 0; i < velocity.num; i++)
            {
                square += (velocity.vel[i] - temp) * (velocity.vel[i] - temp);
            }

            std_dev = Math.Sqrt(square / (velocity.num - 1));

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(folderPath+file_name, true);
            writer.WriteLine("Average= " + temp);
            writer.WriteLine("Max= " + velocity.max);
            writer.WriteLine("Standard Deviation= " + std_dev);
            writer.WriteLine("Right: " + GameManager.gameScore_right + "    Wrong: " + GameManager.gameScore_wrong);
            writer.Close();

            
            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);
    }
}


/*
    

    void timer_0()
    {
        timer_i += 1;

        if (timer_i <= 30)
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
        else if (timer_i == 60)
        {
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
            writer.Close();

            
            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);


        }
        
    }

    
    void timer_faster()
    {
        timer_i += 1;

        if (timer_i <= 30)
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
        else if (timer_i == 45)
        {
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
            writer.Close();

            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);

        }

    }

    void timer_third()
    {
        timer_i += 1;

        if (timer_i <= 20)
        {
            float x_red = UnityEngine.Random.Range(-1f, 1f);
            //float z_red = UnityEngine.Random.Range(-0.5f, 0.5f);    
            float drag_red = UnityEngine.Random.Range(13.0f, 17.0f);
            red.GetComponent<Rigidbody>().drag = drag_red;
            temp_red = Instantiate(red, new Vector3(x_red, 5, 0.7f), Quaternion.identity);
            var yellow_ball = temp_red.GetComponent<Renderer>();
            yellow_ball.material.SetColor("_Color", Color.yellow);

            float x_black = UnityEngine.Random.Range(-1f, 1f);
            //float z_black = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_black = UnityEngine.Random.Range(10.0f, 20.0f);
            black.GetComponent<Rigidbody>().drag = drag_black;
            temp_black = Instantiate(black, new Vector3(x_black, 5, 0.7f), Quaternion.identity);
            var purple_ball = temp_black.GetComponent<Renderer>();
            Color purple = new Color(0.5f, 0, 0.65f, 0.9f);
            purple_ball.material.SetColor("_Color", purple);

            float x_third = UnityEngine.Random.Range(-1f, 1f);
            //float z_third = UnityEngine.Random.Range(-0.5f, 0.5f);
            float drag_third = UnityEngine.Random.Range(10.0f, 20.0f);
            third.GetComponent<Rigidbody>().drag = drag_third;
            temp_third = Instantiate(third, new Vector3(x_third, 5, 0.7f), Quaternion.identity);
            
        }
        else if (timer_i == 55)
        {
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
            writer.Close();

            print("average= " + temp);
            print("Max= " + velocity.max);
            print("std_dev = " + std_dev);

        }

    }
*/
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




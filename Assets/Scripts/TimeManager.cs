using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    private int lastTime;
    private static float timer;
    private int[] xPos = new int[]{2,2,-2,-2};
    private int[] yPos = new int[]{1, -1, 1, -1};

    //create a serialised private transofrm array called transformArray
    [SerializeField]
    private Transform[] transformArray;

    //create a c# 'constant' float member variable called "moveWait" and set it to 2.0f
    private const float moveWait = 2.0f;

    void Start () {
        ResetTime();

        //change camera view from perspective to orthographic
        Camera.main.orthographic = true;

        //set orthographic size of main camera to 2.5f
        Camera.main.orthographicSize = 2.5f;
    }


    private void ResetTime()
    {
        timer = 0;
        
        if (Time.timeScale == 1)
        {
            lastTime = 0;
            Debug.Log(lastTime);
        }
        else if (Time.timeScale == 0)
        {
            lastTime = -1; //needs to be set to 0 and printed when game is unpaused again
        }
    }

    private void MoveObjects()
    {
        //transformArray[0].position = new Vector3(0, 0, 0);
        if (transformArray.position.x == xPos[0]) {
            if (transformArray.position.y == yPos[0])
            {
                Debug.Log("position is 2, 1");
            }
            
            else
            {
                Debug.Log("position is 2, -1");
            }
        }

        if (transformArray.position.x == xPos[2])
        {
            if (transformArray.position.y == yPos[2])
            {
                Debug.Log("position is -2,1");
            }

            else
            {
                Debug.Log("position is -2, -1");
            }
        }
}


    void Update () {

        MoveObjects();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //print to the console "Spacebar pressed"
            Debug.Log("Spacebar pressed");

            //pause and unpause (tip: see Time.timeScale)
            if (Time.timeScale == 0) //0 = paused
            {
                Time.timeScale = 1;

                if (lastTime == -1) //timer has been reset while game was paused so now we need to display that it has been reset
                {
                    lastTime = 0;
                    Debug.Log(lastTime);
                }

            }

            else if (Time.timeScale == 1) //1 = unpaused
            {
                Time.timeScale = 0;
            }


        }

        timer += Time.deltaTime;

        //for every one second that passes, TimeManager should print the time since start of game as an integer seconds value
        if ((timer >= (lastTime + 1)) && (Time.timeScale == 1) && (lastTime != -1))
        {
            lastTime++;
            Debug.Log(lastTime);
            //Debug.Log("actual time = " + Time.time);                      //just me testing how "off" the float is. eg. 1.000543 vs 1.0000
        }


        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetTime();
        }

    }
}

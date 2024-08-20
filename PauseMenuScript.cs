using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    //Declarations
    public GameObject PM;
    public bool paused;




    // Start is called before the first frame update
    void Start()
    {


       
        
    }

    // Update is called once per frame
    void Update()
    {
        Timescale();
        PauseGameActive();
        PauseGameInActive();


    }
    
    public void  Timescale()
    {
        

        if (PM.activeSelf == true && paused == true)
        {
            Time.timeScale = 0;


            

        }
        else
        {



            Time.timeScale = 1;



        }



        


    }
    public void PauseGameActive()
    {
        
        if (Input.GetKey(KeyCode.Escape) == true)
        {
           PM.active = true;

            paused = true;
        }
        else
        {




        }

        




    }
    public void PauseGameInActive()
    {
        if (Input.GetKey(KeyCode.Escape) == true && paused == true)
        {
           // PM.active = false;

          //paused = false;
        }
        else
        {




        }




    }
    





}

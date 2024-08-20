using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class LaserBeamScript : MonoBehaviour
{
    //Declarations
    public RedButtonScript[] button;
    public GameObject laserBeam;


    // Start is called before the first frame update
    void Start()
    {
      
    
        

    }

    // Update is called once per frame
    void Update()
    {
        AllPressedChecker();
        


    }

    
    public void AllPressedChecker()
    {

        foreach (RedButtonScript i in button)
        {
            

            if (i.pressed == true)
            {
                laserBeam.SetActive(false);


            }
            else
            {
                laserBeam.SetActive(true);


            }



        }
        




    }





}

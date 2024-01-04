using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHatchScript : MonoBehaviour
{
    // delcarations
    private CircleCollider2D CC2D;
    private bool playerDetected = false;
    public int storedTurrets = 1;
    public Object turretObj;
    private Animator anime;
   

    // Start is called before the first frame update
    void Start()
    {
        CC2D = GetComponent<CircleCollider2D>();
        anime = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTurret();
        EmptyChecker();
        



    }

    //this code allows the turret to spawn over the hatch when "playerDetection" is set to true
    public void SpawnTurret()
    {
        Vector3 currentPosition;
        Quaternion currentRotation;
        currentPosition = transform.position;
        currentRotation = transform.rotation;
        if (playerDetected == true && storedTurrets > 0)
        {
            


            storedTurrets = storedTurrets - 1;
            Instantiate(turretObj, currentPosition, currentRotation);
        }
        else
        {





        }




    }
    public void EmptyChecker()
    {
        if (storedTurrets <= 0)
        {





        }
        else
        {





        }





    }



    //the following code allows the hatches to detect if a player is within detection range. and if they are, change the value of the "playerDetected"
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true)
        {

            playerDetected = true;


            //Animation code
            if (storedTurrets > 0 ) {


                anime.Play("Hatch opens");


            }
        }







    }

    
    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == false)
        {

            playerDetected = false;

            //Animation code
            if (storedTurrets <= 0 )
            {


                anime.Play("Hatch closes");


            }


        }

    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretTargetingScript : MonoBehaviour

    
{
    //declarations
    //the character the turret aims at
    public Transform target;
    public bool enemyDetectedAnswer = false;
    
    

    // Start is called before the first frame update
    void Start()
    {

        target = GameObject.Find("Player 1").GetComponent<Transform>();

       
      

    }

    // Update is called once per frame
    void Update()
    {
        
        EnemyDetected();
       
        















    }


    public void EnemyDetected()
    {

        if (enemyDetectedAnswer == true) 
        {
            
            // this code make the invisible turret barrel look at the target when the target is detected within the radius
            Vector2 direction = target.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            


        }
        else if (enemyDetectedAnswer == false)
        {
      




        }


    }
    


}

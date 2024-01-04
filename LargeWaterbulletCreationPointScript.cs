using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LargeWaterbulletCreationPointScript : MonoBehaviour
{
    //Declaration
   
    //water bullet prefab that is being created
    public GameObject waterGO;
    //creation point position
    private Vector3 cpPosition;
    //creation point rotation
    private Quaternion cpRotation;
    public RaycastHit2D hit;
    //the time until the character weapon is allowed to fire again.
    public float dontFireTime = 2;
    //the amount the "dontFireTime" will be drained by per second
    public float dontFireDecreaseRate = 1;
    private TurretTargetingScript TTS;


    // Start is called before the first frame update
    void Start()
    {
        dontFireTime = 2;
        dontFireDecreaseRate = 1;
       TTS = GetComponentInParent<TurretTargetingScript>();
        




    }

    // Update is called once per frame
    void Update()
    {
       
        // his code is used to make a ray cast at the "water Creation point" position to fire at the player when the player's "player" tag is detected
        hit = Physics2D.Raycast(transform.position, transform.right);

        
        

        Cooldown();
        
        DontFireTimeCountDown();



        
        
        
    }

    public void WaterCreation()
    {
        if (TTS.enemyDetectedAnswer == true)
        {


            //this code is used to make the water bullet spawn from the positon of the "Water Creation point" on the turret and also make the bullet face the right way before spawning it.
            cpPosition = transform.position;
            cpRotation = transform.rotation;
            Instantiate(waterGO, cpPosition, cpRotation);


        }


    }
    public void ColliderHit()
    {
        // when the Circle collider detects that an object inside its range has a "Player" tag

       


            WaterCreation();

            
            
        
       
        
        
    }
    // a script used to make the turret shoot when its gun is off cooldown.

    public void DontFireTimeCountDown()
    {
        if (dontFireTime > 0)
        {
            dontFireTime = dontFireTime - dontFireDecreaseRate * Time.deltaTime;

        }
        else if(dontFireTime < 0)
        {
            dontFireTime = 2;


        }




    }

    public void Cooldown()
    {
        
        if (hit.collider.tag == "Player" && dontFireTime == 0 || dontFireTime < 0 )
        {
            ColliderHit();

            
           

        }
        else
        {

           

        }

        



    }
   


}

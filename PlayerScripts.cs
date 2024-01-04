using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{// All hard coded variables in methods such as "movement = 10" will have to be revisited.
    
    public bool shield = false;
    public int health = 3;
    public float movementSpeed = 5;
    private Rigidbody2D rb;
    private SpriteRenderer sR;
    private Animator anime;
    public BoxCollider2D bc2D;
    public Vector2 velocity;
    public bool isBoostedA = false;
    public bool isBoostedD = false;
    public bool isBoostedS = false;
    public bool isBoostedW = false;
    public bool boostReady = true;
    private GameObject ObjLayer;
    public float InvulnerabilityTime = 3f;
    public bool Invulnerable = false;
    public float boostCooldownTime = 0f;
    public float boostDuration = 1f;
    public bool recentlyInjured = false;
    public RuntimeAnimatorController rtac1;
    public RuntimeAnimatorController rtac2;
    public RuntimeAnimatorController rtac3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        bc2D = GetComponent<BoxCollider2D>();
        ObjLayer = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
        MoveY();
        BoostSignal();
        Boost();
        BoostCoolDown();
        HurtInvulnerabilityTimer();
        InvulnerabilityTimeReset();
        BoostReset();
        Death();
      
        BoostReadyChecker();
    }

    public void MoveX()
        { 
        rb.velocity = velocity;


        //Movement Code
        if (Input.GetKey(KeyCode.D) == true)
        {
            
            velocity.x = movementSpeed;
            sR.flipX = true;
            //Animation Code
            anime.Play("Running",ObjLayer.layer);
            bc2D.offset = new Vector2(bc2D.offset.x * -1, bc2D.offset.y);
            

        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            velocity.x = -movementSpeed;
            sR.flipX = false;
            //Animation Code
            anime.Play("Running", ObjLayer.layer);
            bc2D.offset = new Vector2(bc2D.offset.x * -1, bc2D.offset.y);
           
        }
        else
        {
            isBoostedA = false;
            isBoostedD = false;
            velocity.x = 0;

            //Animation Code
            if (velocity.y != 0)
            {



            }
            else
            {

                anime.Play("Idle", ObjLayer.layer);
            }
        }


    }

    public void MoveY()
    {

        if (Input.GetKey(KeyCode.S) == true)
        {
            velocity.y = -movementSpeed;

           
            //Animation Code
            anime.Play("Running", ObjLayer.layer);

        }
        else if (Input.GetKey(KeyCode.W) == true)
        {
            velocity.y = movementSpeed;

            
            //Animation Code
            anime.Play("Running", ObjLayer.layer);
        }
        else
        {
            isBoostedS = false;
            isBoostedW = false;

            velocity.y = 0;
            //Animation Code
            if(velocity.x != 0 )
            {

                

            }
            else
            {

                anime.Play("Idle", ObjLayer.layer);
            }
            

        }

    }

    public void BoostCoolDown()
    {
        if (Input.GetKey(KeyCode.Mouse0) == true && boostReady == true && boostCooldownTime <= 0)
        {
           boostCooldownTime = 5f; 


        }
        else
        {
            boostCooldownTime = boostCooldownTime - 1 * Time.deltaTime;
            boostDuration = boostDuration - 1 * Time.deltaTime;



            ResetCoolDownTime();
            ResetBoostDuration();


        }

    }
    // this function
    public void ResetCoolDownTime()
    {

        if (boostCooldownTime < 0)
        {
            boostCooldownTime = 0;


        }
        else
        {




        }



    }
    public void ResetBoostDuration()
    {
        if (boostDuration < 0)
        {
            boostDuration = 0;




        }
        else
        {




        }





    }

    public void BoostReset()
    {
        if (boostDuration < 0)
        {
            boostDuration = 0f;



        }
        else
        {



        }



    }
    public void boostreadyCheck()
    {
        
        if(boostCooldownTime <= 0)
        {
            boostReady = true;



        }
        else
        {
            boostReady = false;


        }


    }

    public void BoostSignal()
    {
      

        //Boost Code
        if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.A) == true && boostReady == true && boostCooldownTime <= 0)
        {
            isBoostedA = true;
            boostDuration = 1;


        }
        else if(Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.D) == true && boostReady == true && boostCooldownTime <= 0)
        {
            isBoostedD = true;
            boostDuration = 1;
        }
        else if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.W) == true && boostReady == true && boostCooldownTime <= 0)
        {
            isBoostedW = true;
            boostDuration = 1;
        }
        else if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.S) == true && boostReady == true && boostCooldownTime <= 0)
        {
            isBoostedS = true;
            boostDuration = 1;
        }
        else 
        {
            movementSpeed = 5;

        }
       
        // this code checks if the value of "boostcooldowntime" is under 0 and sets it back to 0
       

     
    }


    //the following code will be incharge of invincibly boosting the character in one direction at a time
    public void Boost()
    {
        Vector2 verticalForce = Vector2.up;
        Vector2 HorizontalForce = Vector2.left;

        if (isBoostedA == true )
        {
            if (boostDuration > 0 ) {
                velocity.x = -7;
                velocity.y = velocity.y;
                Invulnerable = true;

                anime.runtimeAnimatorController = rtac2 ;

            }
            else
            {
                isBoostedA = false;
                Invulnerable = false;


            }

        }
        else if ( isBoostedW == true )
        {
            if (boostDuration > 0 )
            {
                velocity.x = velocity.x;
                velocity.y = 7;
                Invulnerable = true;

                anime.runtimeAnimatorController = rtac2;

            }
            else
            {
                isBoostedW = false;
                Invulnerable = false;


            }




        }
        else if ( isBoostedS == true )
        {
            if (boostDuration > 0 )
            {
                velocity.x = velocity.x;
                velocity.y = -7;
                Invulnerable = true;

                anime.runtimeAnimatorController = rtac2;

            }
            else
            {
                isBoostedS = false;
                Invulnerable = false;


            }




        }
        else if ( isBoostedD == true)
        {
            if (boostDuration > 0 )
            {
                velocity.x = 7;
                velocity.y = velocity.y;
                Invulnerable = true;

                anime.runtimeAnimatorController = rtac2;

            }
            else
            {
                isBoostedD = false;
                Invulnerable = false;


            }




        }
        else
        {
            if (boostDuration == 0) {
                anime.runtimeAnimatorController = rtac1;



            }



        }






    }

   
   
   


   
    //when the player is hit with a water bullet they will take damage to shield or health
    void OnCollisionEnter2D(Collision2D collision) 
    {

        if (collision.gameObject.tag == "Enemy Projectile" )
        {
            if (Invulnerable == true) 
            {

               
            }
            else
            {
                health = health - 1;
                recentlyInjured = true;


            }
        
        }
        else if(collision.gameObject.tag == "Enemy Projectile" && shield == true)
        {
            shield = false;



        }
        else
        {
            



        }

    }
    public void InvulnerabilityTimeReset()
    {

        if (InvulnerabilityTime <= 0)
        {
            InvulnerabilityTime = 3f;
            recentlyInjured = false;
            Invulnerable = false;



        }
        else
        {




        }



    }
    public void HurtInvulnerabilityTimer()
    {
        if (recentlyInjured == true)
        {
            Invulnerable = true;
            InvulnerabilityTime = InvulnerabilityTime - 1 * Time.deltaTime;



        
        }
        else
        {




        }




    }
   public void Death()
    {
      if(health <= 0)
        {
            movementSpeed = 0;
            anime.runtimeAnimatorController = rtac3;
            anime.Play("Death");

        }
        else
        {


            anime.runtimeAnimatorController = rtac1;



        }

    





    }
    public void BoostReadyChecker()
    {
        if (boostCooldownTime > 0)
        {
            boostReady = false;


        }
        else
        {
            boostReady = true;


        }



    }





}

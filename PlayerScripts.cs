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
    // the PolyGonCollider is being used as a hurt box
    public PolygonCollider2D pc2D;
    public Vector2 velocity;
    public bool isBoostedA = false;
    public bool isBoostedD = false;
    public bool isBoostedS = false;
    public bool isBoostedW = false;
    public bool boostReady = true;
    private GameObject ObjLayer;
    public float InvulnerabilityTime = 1f;
    public bool Invulnerable = false;
    public float boostCooldownTime = 0f;
    public float boostDuration = 1f;
    public bool recentlyInjured = false;
    public RuntimeAnimatorController rtac1;
    public RuntimeAnimatorController rtac2;
    public RuntimeAnimatorController rtac3;
    public bool DeathCheck = false;
    private BarkProjectileCreationPointScript BPCPS;
    private Transform BPCPLS;
    public bool directionUp = false;
    public bool directionDown = false;
    public bool directionLeft = false;
    public bool directionRight = true;
    // this game object is the object that will spawn the bark Projectiles. its full name is Bark Projectile Creation Point
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        bc2D = GetComponent<BoxCollider2D>();
        pc2D = GetComponent<PolygonCollider2D>();
        ObjLayer = this.gameObject;
        BPCPS = GameObject.Find("Bark Projectile Creation Point").GetComponent<BarkProjectileCreationPointScript>();
        BPCPLS = GameObject.Find("Bark Projectile Creation Point").transform;

    }

    // Update is called once per frame
    void Update()
    {
        PlayIdleAnimationWhileIdleY();
        MoveX();
        MoveY();
        Bark();
        BoostSignal();
        Boost();
        BoostCoolDown();
        HurtInvulnerabilityTimer();
        InvulnerabilityTimeReset();
        BoostReset();
        Death();
        CreationPointPositionChanger_Right();
        CreationPointPositionChanger_Left();
        CreationPointPositionChanger_Up();
        CreationPointPositionChanger_Down();
        BoostReadyChecker();
    }

    public void MoveX()
    {
        rb.velocity = velocity;


        //Movement Code
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true) {

            }
            else
            {
                velocity.x = movementSpeed;
                sR.flipX = true;
                //Animation Code
                anime.Play("Running", ObjLayer.layer);
                bc2D.offset = new Vector2(bc2D.offset.x * -1, bc2D.offset.y);

                directionRight = true;

            }

        }
        else if (Input.GetKey(KeyCode.A) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true)
            {

            }
            else
            {

                velocity.x = -movementSpeed;
                sR.flipX = false;
                //Animation Code
                anime.Play("Running", ObjLayer.layer);
                bc2D.offset = new Vector2(bc2D.offset.x * -1, bc2D.offset.y);


                directionLeft = true;
            }


        }
        else
        {
           
            velocity.x = 0;
            directionLeft = false;
            directionRight = false;

        }


    }

    public void MoveY()
    {

        if (Input.GetKey(KeyCode.S) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true)
            {

            }
            else
            {

                velocity.y = -movementSpeed;

                directionDown = true;

                //Animation Code
                if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true)
                {

                    




                }
                else
                {
                    anime.Play("Walk Down", ObjLayer.layer);




                }
                


            }


        }
        else if (Input.GetKey(KeyCode.W) == true)
        {
            if (DeathCheck == true || isBoostedA == true || isBoostedW == true || isBoostedD == true || isBoostedS == true)
            {

            }
            else
            {
                velocity.y = movementSpeed;

                directionUp = true;
                //Animation Code
                if (Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.D) == true) {

                   




                }
                else 
                {
                    anime.Play("Walk Up", ObjLayer.layer);




                }



            }


        }
        else
        {
            velocity.y = 0;
            directionUp = false;
            directionDown = false;
        }

        

    }
    public void Bark()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            BPCPS.FireSignal = true;


        }
        else
        {
            BPCPS.FireSignal = false;
        }
    }
    public void CreationPointPositionChanger_Right()
    {
        if (directionRight == true)
        {
            BPCPLS.gameObject.transform.position.Set(0.4273653f, -0.052f, 0f);
            BPCPLS.gameObject.transform.rotation.Set(0f, 180f, 0f, 0f);

        }
        else
        {


        }

    }
       

    public void CreationPointPositionChanger_Left()
    {
         if (directionLeft == true)
        {
            BPCPLS.position.Set(-0.4273653f, 0.052f, 0f);
            BPCPLS.rotation.Set(0f, 0f, 0f, 0f);
            
           

        }
        else
        {

           
        }
    }
    public void CreationPointPositionChanger_Up()
    {
             if (directionUp == true)
            {
            BPCPLS.transform.position.Set(0f, 0.3f, 0f);
             

            BPCPLS.transform.rotation.Set(0f, 0f, -90f, 0f);
            

            }
            else
            {



            }



    }
       
    
    public void CreationPointPositionChanger_Down()
    {
         if (directionDown == true)
        {
            BPCPLS.gameObject.transform.position.Set(0f, -0.3f, 0f);
            BPCPLS.gameObject.transform.rotation.Set(0f, 0f, 90f, 0f);


        }
        else
        {



        }
    }

    //this function makes it so the "MoveY" Functions dont have to worry about Stopping animations while not moving.
    public void PlayIdleAnimationWhileIdleY()
        {
        //WIP Code
       
         if (velocity.x == 0 && velocity.y == 0)
        {
            anime.Play("Idle", ObjLayer.layer);




        }
        else
        {





        }
    }

    public void BoostCoolDown()
    {
        if (Input.GetKey(KeyCode.Mouse0) == true && boostReady == true && boostCooldownTime <= 0)
        {
           boostCooldownTime = 5f;
           
        }
        else if (DeathCheck != true && isBoostedA != true || isBoostedD != true || isBoostedS != true || isBoostedW != true)
        {
            boostCooldownTime = boostCooldownTime - 1 * Time.deltaTime;
            boostDuration = boostDuration - 1 * Time.deltaTime;
            


            ResetCoolDownTime();
            ResetBoostDuration();


        }

    }
    // this function resets the cool down timer so it does NOT go less than zero
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
    // this function resets the Boost duration timer so it does NOT go less than zero
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
        if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.A) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedA = true;
            boostDuration = 1;


        }
        else if(Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.D) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedD = true;
            boostDuration = 1;
        }
        else if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.W) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
        {
            isBoostedW = true;
            boostDuration = 1;
        }
        else if (Input.GetKey(KeyCode.Mouse0) == true && Input.GetKey(KeyCode.S) == true && boostReady == true && boostCooldownTime <= 0 && DeathCheck == false)
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
                

                anime.runtimeAnimatorController = rtac2 ;

            }
            else
            {
                isBoostedA = false;
                


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
                


            }




        }
        else
        {
            if (boostDuration == 0) {
              anime.runtimeAnimatorController = rtac1;

                Invulnerable = false;

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
    // this function is only used to reset the timer and invulnerable state to normal
    public void InvulnerabilityTimeReset()
    {

        if (InvulnerabilityTime <= 0)
        {
            InvulnerabilityTime = 1f;
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
        else if (recentlyInjured == false) { 
        
            Invulnerable = false;



        }




    }
   public void Death()
    {
      if(health <= 0)
        {
            movementSpeed = 0;
            anime.runtimeAnimatorController = rtac3;
            anime.Play("Death");
            DeathCheck = true;

        }
        else
        {


           // anime.runtimeAnimatorController = rtac1;



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

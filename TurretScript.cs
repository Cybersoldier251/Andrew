using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    //declaration
    private CircleCollider2D CC2D;
    private Animator anime;
    public TurretTargetingScript TTS;
    private Collision2D coll2D;
    public int health = 3;
    private bool shield = false;
    public GameObject thisObject;
    private Object obj;
    



    // Start is called before the first frame update
    void Start()
    {
       
        CC2D = GetComponent<CircleCollider2D>();
        anime = GetComponent<Animator>();
        
        
       
       


    }

    // Update is called once per frame
    void Update()
    {




        






    }

    

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true)
        {
        TTS.enemyDetectedAnswer = true;



        }
        
        

        


    }


    private void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == false)
       {
            TTS.enemyDetectedAnswer = false;



        }

    }



}

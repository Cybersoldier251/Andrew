using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropletScript : MonoBehaviour
{
    //Delcaration
    private Rigidbody2D rb2d;
    private Animator anime;
    private PolygonCollider2D PC2D;
    private Collision2D coll2D;
    public GameObject effect;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        PC2D = GetComponent<PolygonCollider2D>();
        
        


        
        


    }

    // Update is called once per frame
    void Update()
    {
        Velocity();
        

        
    }
    public void Velocity()
    {

       // this code allows the water droplet to move to the direction 
        rb2d.velocity = -transform.right *2;









    }
   

    public void OnCollisionEnter2D()
    {
        Instantiate(effect,transform);
        Destroy(this.gameObject);
        
        
        
      



    }



















}

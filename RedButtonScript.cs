using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButtonScript : MonoBehaviour
{
    //Declaration
    private CircleCollider2D CC2D;
    public bool pressed;
    public bool Timed;
    public float timeleft = 0f;
    private LaserBeamScript LBS;
    private SpriteRenderer Spr;
    public Sprite newSp;
    public Sprite oldSp;
        


    // Start is called before the first frame update
    void Start()
    {
      CC2D =  GetComponent<CircleCollider2D>();
        LBS = GameObject.Find("Laser Beam").GetComponent<LaserBeamScript>();
        Spr = GetComponent<SpriteRenderer>();
      
    }

    // Update is called once per frame
    void Update()
    {
        ButtonPressCheck();

        


    }

    public void ButtonPressCheck()
    {
        if (pressed == true)
        {
            LBS.gameObject.SetActive(false);
             Spr.sprite = newSp;
            

        }
        else
        {

            LBS.gameObject.SetActive(true);
            Spr.sprite = oldSp;

        }

       


    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true)
        {
           
            pressed = true;


        }
        
        





    }


   


}

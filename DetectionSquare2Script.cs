using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSquare2Script : MonoBehaviour
{
    //declaration
    public bool playerDetected = false;
    private PolygonCollider2D PC2D;


    // Start is called before the first frame update
    void Start()
    {
        PC2D = this.GetComponent<PolygonCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.IsTouching(this.PC2D) == true)
        {
            playerDetected = true;



        }






    }


    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player" && other.IsTouching(this.PC2D) == false)
        {
            playerDetected = false;



        }

    }


}

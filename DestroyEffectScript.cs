using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffectScript : MonoBehaviour
{
    //declarations
    private Animator anime ;
    //"Time befor Destroyed" is a value that  is made to be used as reference for the current time to count down to
    private float tbd = 5f;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>();

        currentTime = tbd;

        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyAfterTime();

            
    }

    public void DestroyAfterTime()
    {
        if(currentTime <= 0)
        {
            Destroy(this.gameObject);




        }
        else
        {

            currentTime = currentTime - 1f * Time.deltaTime;


        }
        
        
        



    }



}

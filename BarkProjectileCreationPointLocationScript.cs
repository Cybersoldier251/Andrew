using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkProjectileCreationPointLocationScript : MonoBehaviour
{
    //Declarations
    //this declaration is for the current location of the gameobject its attached to. for the use of moving it later
    public Transform Clocation;
    public Transform Crotation;




    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = Clocation.position;
        gameObject.transform.rotation = Clocation.rotation;
       

    }

    // Update is called once per frame
    void Update()
    {



        
    }




}

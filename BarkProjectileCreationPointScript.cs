using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkProjectileCreationPointScript : MonoBehaviour
{
    //Declaration

    //water bullet prefab that is being created
    public GameObject BarkGO;
    //creation point position
    private Vector3 cpPosition;
    //creation point rotation
    private Quaternion cpRotation;
    public bool FireSignal = false;
    public float CooldownDecreaseRate = 1f;
    public float CooldownCurrentTime ;
    public bool readyToFire = false;
    private PlayerScripts ps;

    // Start is called before the first frame update
    void Start()
    {
        CooldownCurrentTime = 0f;
        CooldownDecreaseRate = 1.0f;

        ps = gameObject.GetComponentInParent<PlayerScripts>();




    }

    // Update is called once per frame
    void Update()
    {
        CooldownTimeTick();
        TimeReset();
        ReadyChecker();
        BarkCreation();










    }

    public void BarkCreation()
    {
        if (FireSignal == true && readyToFire == true)
        {


            //this code is used to make the Bark bullet spawn from the positon of the "Water Creation point" on the turret and also make the bullet face the right way before spawning it.
            cpPosition = transform.position;
            cpRotation = transform.rotation;
            Instantiate(BarkGO, cpPosition, cpRotation);
            CooldownCurrentTime = 1f;

        }
        else
        {
           


        }


    }
    public void TimeReset()
    {
        if (CooldownCurrentTime < 0)
        {


            CooldownCurrentTime = 0;
        }
        else
        {
           

        }



    }
    public void CooldownTimeTick()
    {
        if (CooldownCurrentTime > 0)
        {
            CooldownCurrentTime = CooldownCurrentTime - CooldownDecreaseRate * Time.deltaTime;


        }
    }

    public void ReadyChecker()
    {
        if (CooldownCurrentTime == 0 && ps.DeathCheck == false)
        {
            readyToFire = true;


        }
        else
        {
            readyToFire = false;

            
        }



    }
    


}

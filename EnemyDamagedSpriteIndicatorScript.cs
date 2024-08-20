using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagedSpriteIndicatorScript : MonoBehaviour
{
    //Declarations

    private SpriteRenderer SR;
    public Sprite SP;






    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();

        SP = SR.sprite;
        
    }

    // Update is called once per frame
    void Update()
    {


        LightUpOnDamaged();



    }

    private void LightUpOnDamaged()
    {
        if (true == true)
        {
            SR.color = Color.white;
            

            




        }
        else
        {





        }

        




    }







}

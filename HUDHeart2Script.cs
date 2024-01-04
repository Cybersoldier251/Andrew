using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDHeart2Script : MonoBehaviour
{
    //Declarations
    private PlayerScripts PS;
    private GameObject GO;



    // Start is called before the first frame update
    void Start()
    {
        PS = GameObject.Find("Player 1").GetComponent<PlayerScripts>();
        GO = this.gameObject;



    }

    // Update is called once per frame
    void Update()
    {
        HeartVisibility();




    }

    public void HeartVisibility()
    {
        if (PS.health < 2)
        {
            GO.SetActive(false);


        }
        else
        {
            GO.SetActive(true);


        }



    }
}

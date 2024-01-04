using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHouseScript : MonoBehaviour
{
    //Declarations
    public bool playerWin = false;
    private CircleCollider2D CC2D;
    private Animator anime;
    private PlayerScripts ps;
    public RuntimeAnimatorController AnimeC;


    // Start is called before the first frame update
    void Start()
    {
        CC2D = GetComponent<CircleCollider2D>();
        ps = GameObject.Find("Player 1").GetComponent<PlayerScripts>();
        anime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        PlayerWin();


    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.IsTouching(CC2D) == true)
        {

            playerWin = true;


        }







    }

    public void PlayerWin()
    {
        if(playerWin == true){
            ps.gameObject.SetActive(false);
            anime.runtimeAnimatorController = AnimeC;




        }





    }






}

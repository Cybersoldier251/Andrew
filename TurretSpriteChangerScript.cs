using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpriteChangerScript : MonoBehaviour
{
    //Declarations
    private SpriteRenderer spr;
    private int CurrentRotationPosition;
    public Sprite leftDir;
    public Sprite rightDir;
    public Sprite FowardDir;
    public Sprite BackwardDir;
    private TurretTargetingScript TTS;
    private Animator anime;
    public float timeAfterAwake = 3f;
    private DetectionSquare1Script DSS1;
    private DetectionSquare2Script DSS2;
    private DetectionSquare3Script DSS3;
    private DetectionSquare4Script DSS4;
    public TurretScript TS;


    // Start is called before the first frame update
    void Start()
    {
        
        spr = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        DSS1 = GetComponentInChildren<DetectionSquare1Script>();
        DSS2 = GetComponentInChildren<DetectionSquare2Script>();
        DSS3 = GetComponentInChildren<DetectionSquare3Script>();
        DSS4 = GetComponentInChildren<DetectionSquare4Script>();
        TTS = GameObject.Find("Invisble Sprinkler turret Targeting System").GetComponent<TurretTargetingScript>();

        
        
        
        


    }

    // Update is called once per frame
    void Update()
    {
        timeAfterAwake = timeAfterAwake - 1f * Time.deltaTime;
        SpriteChanger();
        AnimatorDestroyer();





    }

    public void SpriteChanger()
    {
         if( DSS2.playerDetected == true)
        {
            spr.sprite = BackwardDir;
           
        }
        else if (DSS4.playerDetected == true)
        {
            spr.sprite = leftDir;

        }
        else if (DSS1.playerDetected == true)
        {
            spr.sprite = FowardDir;
            
        }
        else if (DSS3.playerDetected == true)
        {
            spr.sprite = rightDir;

        }
        else
        {
            spr.sprite = FowardDir;

        }


         

    }


    public void AnimatorDestroyer()
    {

        if (timeAfterAwake <= 0 && anime != null)
        {
            Destroy(anime.GetComponent<Animator>());
            timeAfterAwake = 0;

        }
        else
        {


        }





    }






}

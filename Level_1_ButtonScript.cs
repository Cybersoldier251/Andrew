using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level_1_ButtonScript : MonoBehaviour   
{
    //Declarations
    private Button Level1Button;
    private SceneManager sm;






    // Start is called before the first frame update
    void Start()
    {
        Level1Button = GetComponent<Button>();
        

        
    }

    // Update is called once per frame
    void Update()
    {
        



    }
    
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
        

        

    }

    


}

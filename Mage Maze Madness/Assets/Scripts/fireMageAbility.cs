using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMageAbility : MonoBehaviour
{

    private bool isFireMage = true;
    //a bool to ensure the player using the script is the right type of mage to use the fire ability
    private bool timerStart;
    //a bool to act as a switch to turn on the timer. 
    private bool hasOrb;
    //a bool to know if the player has the energy to use an ability 

    public float burnTimer = 5.0f;
    //a float that will count down and control the time a hedge stays burned down


    void Update()
    {
        if (isFireMage == true)
        {
            if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
            {
                shootFireball();
                hasOrb = false;
            } else if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
            {
                Debug.Log("You need to collect and energy orb to use an ability.");
            }
        }
        //if the player press F (placeholder input) when they have an energy orb they will shoot the fireball.
     

    }


    void shootFireball()
    {

    }
}

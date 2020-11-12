using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theHunter : BaseMage
{
    public bool isTheHunter;
    //a bool that controls whether the player is marked as The Hunter or not.

    private void Update()
    {
        if (isTheHunter == true)
        {
            //Need to add change the material to look like the hunter
            gameObject.tag = "Hunter";

        }

    }
    //if the player is the Hunter they get the Hunter color and 'Tag'

    public void OnTriggerEnter(Collider other)
    {
        if (isTheHunter == true)
        {
            if (other.gameObject.tag == "FireMage")
            {
                Debug.Log("You have stolen the flames of magic from the Fire Mage.");
                Player.GetComponent<fireMage>().isFireMage = true;
                Player.GetComponent<theHunter>().isTheHunter = false;


            }
        }

    }

    //if the hunter tags a Fire Mage they steal the fire mages power and the mage becomes the Hunter.
    //the swiggle under OnTriggerEnter is okay.


}


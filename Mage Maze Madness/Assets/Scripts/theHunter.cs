using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;

public class theHunter : BaseMage
{
    //a bool that controls whether the player is marked as The Hunter or not.
    public bool isTheHunter;

    //this allows the player to change color to match their mage
    public Material[] hunterC = new Material[6];
    Material[] mats;


    private void Update()
    {
        
        //if a player is the Hunter they get the Hunter Robes and "Hunter" tag.
        if (isTheHunter == true)
        {
            Player.tag = "Hunter";
            hunterRobes();

        }

    }
   

    public void OnTriggerEnter(Collider other)
    {
        //The hunter becomes the type of mage that was tagged
        if (isTheHunter == true)
        {
            if (other.gameObject.tag == "FireMage")
            {
                Debug.Log("You have stolen the flames of magic from the Fire Mage.");
                Player.GetComponent<fireMage>().isFireMage = true;
                Player.GetComponent<theHunter>().isTheHunter = false;

            }

            if (other.gameObject.tag == "LightningMage")
            {
                Debug.Log("You have zapped the electricity of out the Lightning Mage.");
                Player.GetComponent<LightningMage>().isLightningMage = true;
                Player.GetComponent<theHunter>().isTheHunter = false;

            }
            
            if (other.gameObject.tag == "WindMage")
            {
                Debug.Log("You have knocked the wind out of the Wind Mage.");
                Player.GetComponent<WindMage>().isWindMage = true;
                Player.GetComponent<theHunter>().isTheHunter = false;

            }
        }

    }


    void hunterRobes()
    {
        mats = Player.GetComponent<MeshRenderer>().materials;
        mats[0] = hunterC[0];
        mats[1] = hunterC[1];
        mats[2] = hunterC[2];
        mats[3] = hunterC[3];
        mats[4] = hunterC[4];
        mats[5] = hunterC[5];
        Player.GetComponent<MeshRenderer>().materials = mats;

    }

}


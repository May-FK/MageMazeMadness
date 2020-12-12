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
            //hunterRobes();
            this.photonView.RPC("hunterRobes", RpcTarget.AllBuffered);
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
                this.photonView.RPC("BecomeFire", RpcTarget.AllBuffered);
            }

            if (other.gameObject.tag == "LightningMage")
            {
                Debug.Log("You have zapped the electricity of out the Lightning Mage.");
                this.photonView.RPC("BecomeLightning", RpcTarget.AllBuffered);
            }
            
            if (other.gameObject.tag == "WindMage")
            {
                Debug.Log("You have knocked the wind out of the Wind Mage.");
                this.photonView.RPC("BecomeWind", RpcTarget.AllBuffered);                
            }
        }

    }

    [PunRPC]
    void BecomeFire()
    {
        Player.GetComponent<fireMage>().isFireMage = true;
        Player.GetComponent<theHunter>().isTheHunter = false;
    }

    [PunRPC]
    void BecomeWind()
    {
        Player.GetComponent<WindMage>().isWindMage = true;
        Player.GetComponent<theHunter>().isTheHunter = false;
    }

    [PunRPC]
    void BecomeLightning()
    {
        Player.GetComponent<LightningMage>().isLightningMage = true;
        Player.GetComponent<theHunter>().isTheHunter = false;
    }

    [PunRPC]
    void hunterRobes()
    {
        this.Player.tag = "Hunter";
        mats = this.Player.GetComponent<MeshRenderer>().materials;
        mats[0] = hunterC[0];
        mats[1] = hunterC[1];
        mats[2] = hunterC[2];
        mats[3] = hunterC[3];
        mats[4] = hunterC[4];
        mats[5] = hunterC[5];
        this.Player.GetComponent<MeshRenderer>().materials = mats;
    }

}


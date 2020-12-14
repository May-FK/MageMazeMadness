using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;

public class fireMage : BaseMage
{
    //a bool to ensure the player using the script is the right type of mage to use the fire ability
    public bool isFireMage;

    //a bool to act as a switch to turn on the timer. 
    private bool timerStart;

    //a bool to know if the player has the energy to use an ability 
    //[SerializeField] public bool hasOrb;

    //when the player is in a position where theye could use the ability 
    private bool canUseAbility;

    //a float that will count down and control the time a hedge stays burned down
    public float burnTimer = 3.0f;

    //if the player has all the varibles needed to use the ability they can use the ability
    private bool useAbility;

    //A Fire Mage can only have 1 wall burnt down at a time. This a temp variable that stores that wall.
    GameObject wall;

    //this allows the player to change color to match their mage
    public Material[] fireC = new Material[6];

    Material[] mats;

    public Text mana;

    public AudioSource fireSound;
    


    private void Start()
    {
        mana = GameObject.Find("Canvas/Mana").GetComponent<Text>();
        mana.text = "Mana";
        
    }

    void Update()
    {
        if (hasOrb)
        {
            mana.text = "Mana";
        }
        else
        {
            mana.text = "";
        }
        //if a player is a Fire Mage they get the Fire Mage Robes and "Fire" tag.
        if (isFireMage == true)
        {

            //fireRobes();
            this.photonView.RPC("fireRobes", RpcTarget.AllBuffered);

            //If the player has an energy orb they can use their ability.
            if (canUseAbility == true)
            {
                if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
                {
                    this.photonView.RPC("playFireSound", RpcTarget.All);
                    burnWall();
                    hasOrb = false;

                }

                if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
                {
                    Debug.Log("You need to collect and energy orb to use an ability.");

                }
            }

        }


        //the timer for how long the hedge is burned down for.
        if (timerStart == true)
        {
            if (burnTimer > 0)
            {
                burnTimer -= Time.deltaTime;

            }
            else if (burnTimer <= 0)
            {
                timerStart = false;
                burnTimer = 5.0f;
                wall.SetActive(true);
                wall = null;
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (isFireMage == true)
        {
            //If the mage collides with the Hunter, they become the hunter with a brief no tagback delay.
            if (other.gameObject.tag == "Hunter")
            {
                this.photonView.RPC("HunterTrigger2", RpcTarget.AllBuffered);
            }

            //If the FireMage collides with an active interactable wall, the option to use their ability is unlocked.
            if (other.gameObject.CompareTag("iWall") && other.gameObject.activeInHierarchy == true)
            {
                canUseAbility = true;
                Debug.Log("Ability can be used");
            }
        }
    }
    [PunRPC]
    void WallLoad()
    {
        
    }

    [PunRPC]
    void HunterTrigger2()
    {
        Player.GetComponent<fireMage>().isFireMage = false;
        Invoke("BecomeHunter", 1.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        //The FireMage can only use their ability next to a interactable hedge
        if (isFireMage == true)
        {
            canUseAbility = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        //If the FireMage has an orb and is next to an interactable hedge they will use their abiliy 
        if (isFireMage == true)
        {
            if (other.gameObject.CompareTag("iWall") && useAbility == true)
            {
                if (wall == null)
                {
                    wall = other.gameObject;
                    wall.SetActive(false);
                }


                timerStart = true;
                canUseAbility = false;
                useAbility = false;

            }
        }

    }

    [PunRPC]
    void WallTrigger(GameObject wall)
    {
        
        
    }

    [PunRPC]
    void burnWall()
    {
        useAbility = true;

    }

    [PunRPC]
    void playFireSound()
    {
        fireSound.Play(0);
    }


    void BecomeHunter()
    {
        Player.GetComponent<theHunter>().isTheHunter = true;
    }

    [PunRPC]
    void fireRobes()
    {
        Player.tag = "FireMage";
        mats = Player.GetComponent<MeshRenderer>().materials;
        mats[0] = fireC[0];
        mats[1] = fireC[1];
        mats[2] = fireC[2];
        mats[3] = fireC[3];
        mats[4] = fireC[4];
        mats[5] = fireC[5];
        Player.GetComponent<MeshRenderer>().materials = mats;

    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fireMage : BaseMage
{

    public bool isFireMage = false;
    //a bool to ensure the player using the script is the right type of mage to use the fire ability

    private bool timerStart;
    //a bool to act as a switch to turn on the timer. 

    [SerializeField] private bool hasOrb;
    //a bool to know if the player has the energy to use an ability 

    [SerializeField] private bool canUseAbility;
    //when the player is in a position where theye could use the ability 

    public float burnTimer = 5.0f;
    //a float that will count down and control the time a hedge stays burned down

    [SerializeField] private bool useAbility;
    //if the player has all the varibles needed to use the ability they can use the ability

    GameObject wall;
    //A Fire Mage can only have 1 wall burnt down at a time.


    void Update()
    {

        if (isFireMage == true)
        {
            gameObject.tag = "FireMage";
            Player.GetComponent<Renderer>().material = FireRed;

            //if a player is a Fire Mage they get the Fire Red color and the Fire Mage 'Tag'

            if (canUseAbility == true)
            {
                if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
                {
                    burnWall();
                    hasOrb = false;
                }

                if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
                {
                    Debug.Log("You need to collect and energy orb to use an ability.");
                }
            }
            //if the player press F (placeholder input) while they can use their ability, they will call the burn wall function
            //if they press f with no energy it will remind them to collect energy orbs
        }

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
        // this starts timer for how long the hedge is burned down for.

    }



    private void OnTriggerEnter(Collider other)
    {
        if (isFireMage == true)
        {
            if (other.gameObject.tag == "Hunter")
            {
                Player.GetComponent<fireMage>().isFireMage = false;
                Player.GetComponent<Renderer>().material = TransformPink;
                Invoke("BecomeHunter", 3.0f);
            }
            //when the player gets tagged they lose their mage ability and turn pink (place holder color as a visual for the cooldown between tags" 
            //Calls the function BecomeHunter after 3 seconds.




            if (other.gameObject.CompareTag("iWall") && other.gameObject.activeInHierarchy == true)
            {
                canUseAbility = true;
                Debug.Log("Ability can be used");

            }
        }
    }
    //if the player collides with a wall that is interactable (iWall placeholder name) then they unlock the option to use an ability
    //reminder that tag has to be created and applied 

    private void OnTriggerExit(Collider other)
    {
        if (isFireMage == true)
        {
            canUseAbility = false;

        }
    }

    //if the player leaves the hedge that can be interacted with they can no longer use an ability

    private void OnTriggerStay(Collider other)
    {
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
    //while the player is inside the hedge colider if they have all the variables needed to use their ability they can. This will burn down the hedge.
    //The variables also reset.

    void burnWall()
    {

        useAbility = true;
    }
    //Im not sure this is entirely needed. 
    //Where burnWall is being called the action could just be put but maybe well need more for it later so I kept it sepeprated.

    void BecomeHunter()
    {
        Player.GetComponent<theHunter>().isTheHunter = true;
    }
    //this gives the player the Hunter 'Tag' which allows them to tag other players.


}

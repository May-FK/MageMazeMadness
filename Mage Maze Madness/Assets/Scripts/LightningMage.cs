using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningMage : BaseMage
{
    private ThirdPersonMovement control;

    public bool isLightningMage = false;
    //a bool to ensure the player using the script is the right type of mage to use the lightning ability

    private bool timerStart;
    //a bool to act as a switch to turn on the timer. 

    [SerializeField] private bool hasOrb;
    //a bool to know if the player has the energy to use an ability 

    [SerializeField] private bool canUseAbility;

    [SerializeField] private bool useAbility;
    //if the player has all the varibles needed to use the ability they can use the ability

    private float speedMultiplyer = 2.0f;
    private float speedtimer = 5.0f;
    private float controlSpeed;

    // Start is called before the first frame update
    void Start()
    {
        control = this.GetComponent<ThirdPersonMovement>();
        controlSpeed = control.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLightningMage == true)
        {

            //if a player is a lightning they get the Fire Red color and the Fire Mage 'Tag'

            if (canUseAbility == true)
            {
                if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
                {
                    control.speed = controlSpeed * speedMultiplyer;
                    hasOrb = false;
                }

                if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
                {
                    Debug.Log("You need to collect and energy orb to use an ability.");
                }
            }
            //if the player press F (placeholder input) while they can use their ability
            //if they press f with no energy it will remind them to collect energy orbs
        }

        if (timerStart == true)
        {
            if (speedtimer > 0)
            {
                speedtimer -= Time.deltaTime;
            }
            else if (speedtimer <= 0)
            {
                timerStart = false;
                speedtimer = 5.0f;
                control.speed = controlSpeed;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLightningMage == true)
        {
            if (other.gameObject.tag == "Hunter")
            {
                Player.GetComponent<fireMage>().isFireMage = false;
                Player.GetComponent<Renderer>().material = TransformPink;
                Invoke("BecomeHunter", 3.0f);
            }
            //when the player gets tagged they lose their mage ability and turn pink (place holder color as a visual for the cooldown between tags" 
            //Calls the function BecomeHunter after 3 seconds.
        }
    }
    

    //if the player leaves the hedge that can be interacted with they can no longer use an ability
}

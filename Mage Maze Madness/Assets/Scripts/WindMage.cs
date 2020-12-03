using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMage : BaseMage
{
    public bool isWindMage;
    //public bool hasOrb;

    public float jumpSpeed = 20.0f;
    private PlayerController pc;

    public Material[] windC = new Material[6];
    Material[] mats;


    void Start()
    {
        pc = gameObject.GetComponentInParent<PlayerController>();
    }


    void Update()
    {
        if (isWindMage == true)
        {
            WindRobes();
            Player.tag = "WindMage";

            //If the player has an energy orb they can use their ability.
            if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
            {
                pc.jump = true;
                //pc.characterController.Move(pc.moveDirection * Time.deltaTime);
                hasOrb = false;
            }

            if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
            {
                Debug.Log("You need to collect and energy orb to use an ability.");
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isWindMage == true)
        {
            //If the mage collides with the Hunter, they become the hunter with a brief no tagback delay.
            if (other.gameObject.tag == "Hunter")
            {
                Player.GetComponent<WindMage>().isWindMage = false;
                Invoke("BecomeHunter", 1.0f);

            }
        }
    }

    void BecomeHunter()
    {
        Player.GetComponent<theHunter>().isTheHunter = true;

    }

    void WindRobes()
    {
        mats = Player.GetComponent<MeshRenderer>().materials;
        mats[0] = windC[0];
        mats[1] = windC[1];
        mats[2] = windC[2];
        mats[3] = windC[3];
        mats[4] = windC[4];
        mats[5] = windC[5];
        Player.GetComponent<MeshRenderer>().materials = mats;

    }
}

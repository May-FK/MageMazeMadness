using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMage : BaseMage
{
    public bool hasOrb;
    public bool isWindMage;
    public float jumpSpeed = 20.0f;
    public PlayerController pc;

    public Material[] MageC = new Material[6];
    Material[] mats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isWindMage == true)
        {
            WindRobes();
            Player.tag = "WindMage";

            //If the player has an energy orb they can use their ability.
            if (Input.GetKeyDown(KeyCode.F) && hasOrb == true)
            {
                pc.moveDirection.y = jumpSpeed;
                hasOrb = false;
            }

            if (Input.GetKeyDown(KeyCode.F) && hasOrb == false)
            {
                Debug.Log("You need to collect and energy orb to use an ability.");
            }

        }
    }

    void WindRobes()
    {
        mats = Player.GetComponent<MeshRenderer>().materials;
        mats[0] = MageC[0];
        mats[1] = MageC[1];
        mats[2] = MageC[2];
        mats[3] = MageC[3];
        mats[4] = MageC[4];
        mats[5] = MageC[5];
        Player.GetComponent<MeshRenderer>().materials = mats;

    }
}

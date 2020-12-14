using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float cooldownTime = 5.0f;
    float timeRemaining;

    bool spawned = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTime > 0)
        {
            cooldownTime -= Time.deltaTime;
        }
        else if ((cooldownTime <= 0) && (spawned == false))
        {
            spawned = true;
        }

        if (spawned)
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (spawned)
        {
            if (other.CompareTag("LightningMage"))
            {
                other.GetComponent<LightningMage>().hasOrb = true;
                spawned = false;
                timeRemaining = cooldownTime;
            }

            if (other.CompareTag("FireMage"))
            {
                other.GetComponent<fireMage>().hasOrb = true;
                spawned = false;
                timeRemaining = cooldownTime;
            }

            if (other.CompareTag("WindMage"))
            {
                other.GetComponent<WindMage>().hasOrb = true;
                spawned = false;
                timeRemaining = cooldownTime;
            }
        }
    }

    /*private void OnTriggerStay(Collider other)
    {
        if (spawned)
        {
            if ((other.CompareTag("LightningMage")) || (other.CompareTag("FireMage")) || (other.CompareTag("WindMage")))
            {
                other.GetComponent<LightningMage>().hasOrb = true;
                other.GetComponent<fireMage>().hasOrb = true;
                other.GetComponent<WindMage>().hasOrb = true;
                spawned = false;
                timeRemaining = cooldownTime;
            }
        }
    }*/
}

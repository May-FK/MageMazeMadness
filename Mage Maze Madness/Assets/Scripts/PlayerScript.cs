using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviourPunCallbacks
{
   
    private void Awake()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {

            PlayerController playerController = GetComponent<PlayerController>();
            CharacterController characterController = GetComponent<CharacterController>();
            Camera camera = GetComponentInChildren<Camera>();
            //theHunter hunter = GetComponentInChildren<theHunter>();
            WindMage wind = GetComponentInChildren<WindMage>();
            fireMage fire = GetComponentInChildren<fireMage>();
            LightningMage lightning = GetComponentInChildren<LightningMage>();
            //thePlayer = GetComponentInChildren<>();

            //hunter.enabled = false;
            wind.enabled = false;
            fire.enabled = false;
            lightning.enabled = false;
            camera.enabled = false;
            playerController.enabled = false;
            characterController.enabled = false;




        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (photonView.InstantiationId == 1001)
        {
            //Debug.Log("This is Player1");
            gameObject.name = "Player1";
        }

        if (photonView.InstantiationId == 2001)
        {
            //Debug.Log("This is Player2");
            gameObject.name = "Player2";
        }

        if (photonView.InstantiationId == 3001)
        {
            //Debug.Log("This is Player3");
            gameObject.name = "Player3";
        }

        if (photonView.InstantiationId == 4001)
        {
            //Debug.Log("This is Player4");
            gameObject.name = "Player4";
        }

        if (photonView.InstantiationId == 5001)
        {
            //Debug.Log("This is Player5");
            gameObject.name = "Player5";
        }

        if (photonView.InstantiationId == 6001)
        {
            //Debug.Log("This is Player6");
            gameObject.name = "Player6";
        }

        if (photonView.InstantiationId == 7001)
        {
            //Debug.Log("This is Player7");
            gameObject.name = "Player7";
        }

        if (photonView.InstantiationId == 8001)
        {
            //Debug.Log("This is Player8");
            gameObject.name = "Player8";
        }

    }
}

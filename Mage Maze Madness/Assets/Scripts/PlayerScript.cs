using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Awake()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            
            PlayerController playerController = GetComponent<PlayerController>();
            CharacterController characterController = GetComponent<CharacterController>();
            Camera camera = GetComponentInChildren<Camera>();
            theHunter hunter = GetComponentInChildren<theHunter>();
            WindMage wind = GetComponentInChildren<WindMage>();
            fireMage fire = GetComponentInChildren<fireMage>();
            LightningMage lightning = GetComponentInChildren<LightningMage>();
            //thePlayer = GetComponentInChildren<>();

            hunter.enabled = false;
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

    }
}

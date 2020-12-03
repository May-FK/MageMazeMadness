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

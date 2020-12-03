using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;
public class playerCreator : MonoBehaviourPunCallbacks
{
    public GameObject theMage;


    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(this.theMage.name, new Vector3(0f, 10f, 0f), Quaternion.identity);
        
    }

}

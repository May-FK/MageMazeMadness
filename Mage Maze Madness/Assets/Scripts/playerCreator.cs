using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.Demo.PunBasics;
public class playerCreator : MonoBehaviourPunCallbacks
{
    public GameObject theHunter;
    public GameObject theFireMage;
    public GameObject theWindMage;
    public GameObject theLightningMage;

    [Range(0, 3)]
    public int charNum;
    


    public override void OnJoinedRoom()
    {
        if (charNum == 0)
        {
            PhotonNetwork.Instantiate(this.theHunter.name, new Vector3(1f, 10f, 1f), Quaternion.identity);
        }
        else if (charNum == 1)
        {
            PhotonNetwork.Instantiate(this.theFireMage.name, new Vector3(-1f, 10f, 0f), Quaternion.identity);
        }
        if (charNum == 2)
        {
            PhotonNetwork.Instantiate(this.theWindMage.name, new Vector3(1f, 10f, -1f), Quaternion.identity);
        }
        if (charNum == 3)
        {
            PhotonNetwork.Instantiate(this.theLightningMage.name, new Vector3(-1f, 10f, -1f), Quaternion.identity);
        }


    }

}

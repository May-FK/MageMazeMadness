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

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetNum0()
    {
        charNum = 0;
    }
    public void SetNum1()
    {
        charNum = 1;
    }
    public void SetNum2()
    {
        charNum = 2;
    }
    public void SetNum3()
    {
        charNum = 3;
    }

    public override void OnJoinedRoom()
    {
        if (charNum == 0)
        {
            PhotonNetwork.Instantiate(this.theHunter.name, new Vector3(10f, 10f, 10f), Quaternion.identity);
        }
        if (charNum == 1)
        {
            PhotonNetwork.Instantiate(this.theFireMage.name, new Vector3(-10, 10f, 10f), Quaternion.identity);
        }
        if (charNum == 2)
        {
            PhotonNetwork.Instantiate(this.theWindMage.name, new Vector3(10f, 10f, -10f), Quaternion.identity);
        }
        if (charNum == 3)
        {
            PhotonNetwork.Instantiate(this.theLightningMage.name, new Vector3(-10f, 10f, -10f), Quaternion.identity);
        }


    }

}

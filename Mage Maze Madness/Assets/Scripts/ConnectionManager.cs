﻿using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Photon.Pun.Demo.PunBasics;

public class ConnectionManager : MonoBehaviourPunCallbacks //THIS LINE IN IMPORTANT. REMEMBER TO ADD PUNCALLBACKS
{
    string gameVersion = ".1";

    [SerializeField]
    private byte maxPlayersPerRoom = 8;
    //creating a byte which is similair to an int to hold the max number of players pe      
    //Serialized field allows the private varible to be edited in the unity console

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        ConnectGame();

    }
    // at the start of the game all the players will load the same level 

    void Update()
    {

    }
    public void ConnectGame()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    //when the game connects the photon gameversion will be set equal to the game version variable we created.

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinRandomRoom();
    }
    //when the system verifies we connected to the master version it tries to join a random room

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Oops! You got disconnected.");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }
    //if no lobby can be found we will create a new lobby with our current max players per room variable.
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A mage has entered the maze!");
    }
    //when a player enters the room this message appears.

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("A mage has left the maze.");
    }
    //when a player leaves the room this message appears.
}

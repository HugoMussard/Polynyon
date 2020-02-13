using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;

/*
Script final du lobby, le reste est du trash file
*/

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    
    public static PhotonLobby lobby;



    public Button CreateOrjoinButton;

    public Button Cancel;
    
    public InputField nom;

    public Text InfoOnConnection;
    
    // Start is called before the first frame update
    private void Awake()
    {
        lobby = this;
        PhotonNetwork.AutomaticallySyncScene = true;
        
    }


    private void Start()
    {

        PhotonNetwork.ConnectUsingSettings();
        InfoOnConnection.text = "Starting...";
        CreateOrjoinButton.interactable = false;
        Cancel.interactable = false;
    }
    
    

    public void OnJoinOrCreateButton()
    {

        JoinOrCreateRoom();
    }

    public void OnCancelClick()
    {
        CreateOrjoinButton.interactable = true;
        Cancel.interactable = false;

        PhotonNetwork.LeaveRoom();
        
    }

    private void JoinOrCreateRoom()
    {
        if (nom.text == "" || nom.text == null)
        {
            InfoOnConnection.text = "Please write a room name";
            return;

        }
        
        CreateOrjoinButton.interactable = false;
        Cancel.interactable = true;
        string nomchambre = nom.text;
        RoomOptions RoomOps = new RoomOptions(){IsVisible = true, IsOpen = true, MaxPlayers = 2};
        Debug.Log("On cree une chambre ID : " +nomchambre);
        
        
        PhotonNetwork.JoinOrCreateRoom(nomchambre, RoomOps, TypedLobby.Default);

    }



    public override void OnJoinedRoom()
    {
        Debug.Log("On est dans une room + "+ PhotonNetwork.CurrentRoom.Name
        + "avec {1} joueurs" +PhotonNetwork.CurrentRoom.Players.Count);
        
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            Debug.Log(Convert.ToString(PhotonNetwork.CurrentRoom.Players.Count));

            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
                InfoOnConnection.text = "waiting for a player";
            
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
                InfoOnConnection.text = "You have been rejoined";

        }
    }

    public override void OnConnectedToMaster()
    {

        CreateOrjoinButton.interactable = true;
        InfoOnConnection.text = "Connected to the servers";
        
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        InfoOnConnection.text = "Failed to connect to room : " + message;
        OnCancelClick();
    }


}

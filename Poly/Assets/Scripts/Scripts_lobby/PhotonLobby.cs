using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = System.Random;
using UnityEngine.SceneManagement; 

/*
Script final du lobby, le reste est du trash file
*/

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    
    public static PhotonLobby lobby;

    public Button CreateOrjoinButton;

    public Button Cancel;

    public TMP_InputField nom;

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
        PlayerPrefs.SetString("roomname", nomchambre);
        PlayerPrefs.Save();
        RoomOptions RoomOps = new RoomOptions {IsVisible = true, IsOpen = true, MaxPlayers = 2};
        Debug.Log("On cree une chambre ID : " + nomchambre);
        PhotonNetwork.JoinOrCreateRoom(nomchambre, RoomOps, TypedLobby.Default);

    }

    public void BackToMenu()
    {
        PhotonNetwork.Disconnect();
        SceneManager.UnloadSceneAsync("lobby");
        SceneManager.LoadScene("MENUOK", LoadSceneMode.Additive);
    }


    public override void OnJoinedRoom()
    {
        Debug.Log("On est dans une room + "+ PhotonNetwork.CurrentRoom.Name
        + "avec {1} joueurs" + PhotonNetwork.CurrentRoom.Players.Count);
        
    }

    private void Update()
    {
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                InfoOnConnection.text = "Waiting for a player";
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.UnloadSceneAsync("lobby");
                    SceneManager.LoadSceneAsync("Load_NewGame", LoadSceneMode.Additive); 
                }  
            }

            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    SceneManager.UnloadSceneAsync("lobby");
                    SceneManager.LoadSceneAsync("Load_NewGame", LoadSceneMode.Additive); 
                }    
                else
                    InfoOnConnection.text = "Waiting for Player1"; 
            }

        }
    }

    public override void OnConnectedToMaster()
    {
        CreateOrjoinButton.interactable = true;
        InfoOnConnection.text = "Connected to the server";
        
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        InfoOnConnection.text = "Failed to connect to room : " + message;
        OnCancelClick();
    }


}

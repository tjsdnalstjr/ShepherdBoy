using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("마스터 연결");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("로비 입장");
        
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string nick = "dd";
        PhotonNetwork.LocalPlayer.NickName = nick;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "map", "ai" };
        roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable() { { "map", 1 } };
        roomOptions.MaxPlayers = 6;

        PhotonNetwork.CreateRoom(nick + "님의 방", roomOptions);
    }
}

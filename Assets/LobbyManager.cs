using System.Collections;
using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static string levelChoice;

    private ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();

    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1, 10000);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady && !PhotonNetwork.InRoom)
            PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        
    }


    public void JoinRoom()
    {
        if(PhotonNetwork.IsConnectedAndReady && !PhotonNetwork.InRoom)
            PhotonNetwork.JoinRandomRoom();
    }

    public void LoadScene()
    {
        if (PhotonNetwork.InRoom)
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel(levelChoice);
        }
        else
            SceneManager.LoadScene(levelChoice);
    }

    public void LeveRoom()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("mainmenu");

    }

    public override void OnJoinedRoom()
    {
        customProperties["wheels"] = CustomizationScript.wheelsPrefab.name;
        customProperties["colorr"] = CustomizationScript.mainColor.r;
        customProperties["colorg"] = CustomizationScript.mainColor.g;
        customProperties["colorb"] = CustomizationScript.mainColor.b;
        PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
        Debug.Log(PhotonNetwork.LocalPlayer.CustomProperties["wheels"]);
    }

}

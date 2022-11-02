using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject RoomPanel;

    public GameObject CreatePanel;
    public Text roomidText;

    public GameObject JoinPanel;
    public InputField roomidInput;
    public void Connect() => PhotonNetwork.ConnectUsingSettings(); // 서버 접속 시도

    void Awake()
    {
        Screen.SetResolution(1020, 1980, false);
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        Connect();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("서버 접속 완료");
    }

    public void OnClickCreateBtn()
    {
        string roomid = Random.Range(0, 1000000).ToString("D6");
        PhotonNetwork.CreateRoom(roomid, new RoomOptions { MaxPlayers = 2 });
        roomidText.text = "방 번호 : " + roomid;
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성 완료");
        RoomPanel.SetActive(false);
        CreatePanel.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void Update()
    {
        // 안드로이드 뒤로가기는 컴퓨터 Esc키임
        if(Input.GetKeyDown(KeyCode.Escape) && PhotonNetwork.IsConnected)
        {
            PhotonNetwork.LeaveRoom();
            Debug.Log("방 삭제");
            RoomPanel.SetActive(true);
            CreatePanel.SetActive(false);
            JoinPanel.SetActive(false);
        }
    }

    public void OnClickJoinBtn()
    {
        RoomPanel.SetActive(false);
        JoinPanel.SetActive(true);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomidInput.text);
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}

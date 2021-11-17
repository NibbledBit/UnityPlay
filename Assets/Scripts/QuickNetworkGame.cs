using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class QuickNetworkGame : MonoBehaviourPunCallbacks {

    [SerializeField]
    int maxPlayers = 2;

    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log($"Connected to {PhotonNetwork.CloudRegion} server");
        PhotonNetwork.AutomaticallySyncScene = true;
        JoinRandomRoom();
    }
    private void JoinRandomRoom() {
        Debug.Log("Joining Random Room.");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log($"Join Random Room Failed {returnCode} {message}");
        CreateRoom();
    }
    private static System.Random Random = new System.Random();
    private void CreateRoom() {
        Debug.Log("Creating Room");
        int randomNumber = Random.Next(0, 10000);
        RoomOptions options = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 2 };
        PhotonNetwork.CreateRoom($"Room {randomNumber}", options);
        Debug.Log($"Connecting to Random Room {randomNumber}");
    }
    public override void OnCreateRoomFailed(short returnCode, string message) {
        Debug.Log($"Create Room Failed {returnCode} {message}");
        CreateRoom();
    }
    public override void OnEnable() {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable() {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom() {
        Debug.Log("Joined Room");
        if (PhotonNetwork.PlayerList.Length >= maxPlayers) {
            StartGame();
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) {
        if (PhotonNetwork.PlayerList.Length >= maxPlayers) {
            StartGame();
        }
    }
    private void StartGame() {
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel("SampleScene");
        }
    }
}
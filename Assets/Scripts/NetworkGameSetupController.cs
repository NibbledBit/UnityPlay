using Photon.Pun;
using UnityEngine;

public class NetworkGameSetupController : MonoBehaviour {
    void Start() {
        CreatePlayer();
    }

    private void CreatePlayer() {
        Debug.Log("Creating Player");
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        }
        else {
            PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
        }
    }
}

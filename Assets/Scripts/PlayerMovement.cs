using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float Speed;

    private PhotonView photonView;
    private float x;
    private float y;

    private void Start() {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update() {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) {
            return;
        }

        x = Input.GetAxisRaw("Horizontal") * Speed;
        y = Input.GetAxisRaw("Vertical") * Speed;
    }

    void FixedUpdate() {
        transform.position += new Vector3(x, y);
    }
}

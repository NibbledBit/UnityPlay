using Photon.Pun;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform shootPoint;

    PhotonView photonView;
    void Start() {
        photonView = GetComponent<PhotonView>();
    }
    void Update() {
        if (!photonView.IsMine && PhotonNetwork.IsConnected) {
            return;
        }

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        if (PhotonNetwork.IsConnected) {
            PhotonNetwork.Instantiate("Bullet", shootPoint.position, shootPoint.rotation);
        }
        else {
            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        }
    }
}
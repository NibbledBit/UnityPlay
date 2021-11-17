using Photon.Pun;
using UnityEngine;

public class TransformFaceMouse : MonoBehaviour {
    private PhotonView myView;

    private void Start() {
        myView = GetComponent<PhotonView>();
    }
    void Update() {
        if (!myView.IsMine && PhotonNetwork.IsConnected) {
            return;
        }

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 mouseInWorld = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 lookAtVector = mouseInWorld - transform.position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(lookAtVector.y, lookAtVector.x);

        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 300);
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    float Speed;

    [SerializeField]
    Rigidbody2D bulletBody;

    void Start() {
        bulletBody.velocity = transform.right * Speed;
    }
}

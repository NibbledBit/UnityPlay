using UnityEngine;

public class BulletCollision : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log($"Collision with: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Player")) {
            DamagePlayer(collision);
        }
        //else if (collision.gameObject.CompareTag("Wall")) {
        //    Bounce(collision);
        //}
    }

    private void DamagePlayer(Collision2D collision) {
        Destroy(this.gameObject);
    }

    private void Bounce(Collision2D collision) {
        //Boucing is caused via the Physics Material 2D
        //Could add some randomness here (Ricochet effect)
    }
}

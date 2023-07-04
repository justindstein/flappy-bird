using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D rigidbody2D;
    public float flapStrength;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = Vector2.up * this.flapStrength;
        }
    }
}

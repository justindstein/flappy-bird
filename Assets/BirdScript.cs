using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D rigidbody2D;
    public float flapStrength;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = Vector2.up * this.flapStrength;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D rigidbody2D;
    public float flapStrength;

    // Start is called before the first frame update
    void Start() {
        //gameObject.name = "Bob Birdington";
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            rigidbody2D.velocity = Vector2.up * this.flapStrength;
            //Debug.Log("GetKeyDown->KeyCode.Space: " + this.rigidbody2D.velocity);

        } else if(Input.GetKey(KeyCode.Space)) {
            //rigidbody2D.velocity = Vector2.Scale(rigidbody2D.velocity, new Vector2(0, (float)1.0001));
            //rigidbody2D.velocity = Vector2.Add
            //Debug.Log("GetKeyDown->GetKey.Space: " + this.rigidbody2D.velocity);
        }
    }
}

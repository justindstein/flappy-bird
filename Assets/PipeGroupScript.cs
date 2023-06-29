using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGroupScript : MonoBehaviour {
    public float moveSpeed;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.position + ((Vector3.left * this.moveSpeed) * Time.deltaTime);
    }
}

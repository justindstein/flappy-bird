using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGroupColliderScript : MonoBehaviour {

    private LogicManagerScript logicManagerScript;

    // Start is called before the first frame update
    void Start() {
        this.logicManagerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        this.logicManagerScript.incrementScore();
    }
}

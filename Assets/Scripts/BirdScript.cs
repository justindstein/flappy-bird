using UnityEngine;

public class BirdScript : MonoBehaviour {

    public Rigidbody2D rigidbody2D;
    public float flapStrength;

    private LogicManagerScript logicManagerScript;
    bool isAlive = true;

    void Start() {
        this.logicManagerScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) && this.isAlive) {
            rigidbody2D.velocity = Vector2.up * this.flapStrength;
        }
    }

    // Collision with pipes
    private void OnCollisionEnter2D(Collision2D collision) {
        this.logicManagerScript.activateGameOverScreen();
        this.isAlive = false;
    }

    // Bird goes off-screen
    public void OnBecameInvisible() {
        this.logicManagerScript.activateGameOverScreen();
        this.isAlive = false;
    }

    public bool IsAlive() {
        return this.isAlive;
    }

}

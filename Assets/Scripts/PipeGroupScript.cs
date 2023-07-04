using UnityEngine;

public class PipeGroupScript : MonoBehaviour {

    public float moveSpeed;
    public bool isVisible;

    // Update is called once per frame
    void Update() {
        transform.position = transform.position + ((Vector3.left * this.moveSpeed) * Time.deltaTime);
    }

    void OnBecameVisible() {
        this.isVisible = true;
    }

    void OnBecameInvisible() {
        this.isVisible = false;
    }

    public bool IsInvisible() {
        return !this.isVisible;
    }
}

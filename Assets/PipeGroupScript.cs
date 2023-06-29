using UnityEngine;
using Debug = UnityEngine.Debug;

public class PipeGroupScript : MonoBehaviour {
    public float moveSpeed;
    public bool isVisible;

    // Start is called before the first frame update
    void Start() {
        Debug.Log("Instantiating, becoming visible");
    }

    // Update is called once per frame
    void Update() {
        transform.position = transform.position + ((Vector3.left * this.moveSpeed) * Time.deltaTime);
    }

    void OnBecameVisible() {
        Debug.Log("Becoming visible");
        this.isVisible = true;
    }

    void OnBecameInvisible() {
        Debug.Log(string.Format("Becoming invisible"));
        this.isVisible = false;
    }

    public bool IsInvisible() {
        return !this.isVisible;
    }
}

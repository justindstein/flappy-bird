using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneColliderScript : MonoBehaviour
{
    //public GameObject pipeGroupSpawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(string.Format("contact between: {0} and {1}", collision.collider.name, collision.otherCollider.name));
    }
}

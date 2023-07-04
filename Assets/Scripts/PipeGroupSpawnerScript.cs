using System.Collections.Generic;
using UnityEngine;

public class PipeGroupSpawnerScript : MonoBehaviour {
    public GameObject pipeGroup;

    private float spawnRate = 2;
    private float timer = 2;
    private Queue<GameObject> pipeGroups;

    // Start is called before the first frame update
    void Start() {
        this.pipeGroups = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        GameObject pipeGroup = this.pipeGroup;
        float spawnRate = this.spawnRate;
        Queue<GameObject> pipeGroups = this.pipeGroups;

        // Spawn pipeGroup after enough deltaTime has elapsed
        if (getUpdatedTimer(Time.deltaTime) >= spawnRate) {
            InstantiatePipeGroup(pipeGroup, pipeGroups);
            resetTimer();
        }

        // Cleanup invisible pipeGroups
        //while (containsInvisiblePipeGroup(pipeGroups)) {
        //    Destroy(pipeGroups.Dequeue());
        //}
    }

    private void InstantiatePipeGroup(GameObject pipeGroup, Queue<GameObject> pipeGroups) {
        GameObject instance = Instantiate(pipeGroup, transform.position + GetPositionWithHeightBetween(-1, 1), transform.rotation);
        instance.AddComponent<PipeGroupScript>();
        pipeGroups.Enqueue(instance);
    }

    private void resetTimer() {
        this.timer = 0;
    }

    private float getUpdatedTimer(float deltaTime) {
        this.timer += deltaTime;
        return this.timer;
    }

    private Vector3 GetPositionWithHeightBetween(float minY, float maxY) {
        Vector3 vector = new Vector3(0, Random.Range(minY, maxY), 0); ;
        return vector;
    }

    private bool containsInvisiblePipeGroup(Queue<GameObject> pipeGroups) {
        return (pipeGroups.Count > 0)
            && (pipeGroups.Peek() != null)
            && (pipeGroups.Peek().GetComponent<PipeGroupScript>().IsInvisible())
        ;
    }
}

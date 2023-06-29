using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PipeGroupSpawnerScript : MonoBehaviour {
    public GameObject pipeGroup;

    private float spawnRate = 2;
    private float timer = 2;
    private HashSet<GameObject> pipeGroups; // TODO: Queue with peek would be more efficient

    // Start is called before the first frame update
    void Start() {
        this.pipeGroups = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update() {
        this.timer += Time.deltaTime;
        //Debug.Log("this.timer: " + this.timer + " this.spawnRate: " + this.spawnRate);

        if (this.timer >= this.spawnRate) {
            this.timer = 0;
            instantiatePipeGroup();
        }

        HashSet<GameObject> gameObjectsToDestroy = new HashSet<GameObject>();
        CameraField cameraField = new CameraField(Camera.main);
        foreach (GameObject pipeGroup in pipeGroups) {
            if (cameraField.shouldDespawnPipeGroup(pipeGroup.transform.position)) {
                gameObjectsToDestroy.Add(pipeGroup);
            }
        }

        foreach (GameObject gameObjectToDestroy in gameObjectsToDestroy) {
            this.pipeGroups.Remove(pipeGroup);
            Debug.Log(string.Format("Removing and destroying pipeGroup: {0}", pipeGroup));
            DestroyImmediate(pipeGroup, true);
        }
    }

    private void instantiatePipeGroup() {
        GameObject pipeGround = Instantiate(this.pipeGroup, transform.position + getPositionWithHeightBetween(-1, 1), transform.rotation);
        this.pipeGroups.Add(pipeGround);
    }

    private Vector3 getPositionWithHeightBetween(float minY, float maxY) {
        Vector3 vector = new Vector3(0, Random.Range(minY, maxY), 0); ;
        Debug.Log(string.Format("getPositionWithHeightBetween({0},{1}): {2}", minY, maxY, vector));
        return vector;
    }

    private class CameraField {

        private Vector3 bottomLeft;
        private Vector3 topRight;

        public CameraField(Camera camera) {
            Vector3 position = camera.transform.position;
            float orthographicSize = camera.orthographicSize;
            this.bottomLeft = new Vector3(position.x - orthographicSize, position.y - orthographicSize, -1);
            this.topRight = new Vector3(position.x + orthographicSize, position.y + orthographicSize, -1);
        }

        // Does not work as pipeGroups are spawned outside of cameraField (to the right)
        public bool isPositionInCameraField(Vector3 position) {
            bool isPositionInCameraField = (position.x > bottomLeft.x)
                && (position.y > bottomLeft.y)
                && (position.x < topRight.x)
                && (position.y < topRight.y)
            ;

            Debug.Log(string.Format("isPositionInCameraField: {0} between {1} and {2}: {3}", position, this.bottomLeft, this.topRight, isPositionInCameraField));
            return isPositionInCameraField;
        }

        public bool shouldDespawnPipeGroup(Vector3 position) {
           return (position.x < bottomLeft.x);
        }
    }
}

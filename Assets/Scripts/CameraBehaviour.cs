using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {
    Vector3 lastMousePosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Camera.main.ScreenToPlane(Input.mousePosition);
        }
        var mouseDelta = lastMousePosition - Camera.main.ScreenToPlane(Input.mousePosition);
        mouseDelta *= Input.GetMouseButton(1) ? 1 : 0;
        this.transform.position = new Vector3(
            transform.position.x + mouseDelta.x,
            transform.position.y + mouseDelta.y,
            transform.position.z + Input.mouseScrollDelta.y
        );
    }
}

using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, 0));
        float distance;
        xy.Raycast(ray, out distance);
        var mousePosition = ray.GetPoint(distance);
        mousePosition.Scale(new Vector3(1, 1, 0));
        gameObject.transform.position = mousePosition;
	}
}

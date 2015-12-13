using UnityEngine;
using System.Collections;

public class Sticky : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(var spring in gameObject.GetComponents<SpringJoint2D>())
            if (spring.connectedBody.gameObject == collision.gameObject) return;
        var springJoint = gameObject.AddComponent<SpringJoint2D>();
        springJoint.connectedBody = collision.rigidbody;
        springJoint.enableCollision = false;
        springJoint.distance = 1;
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpringJoint2D))]
[RequireComponent(typeof(LineRenderer))]
public class SpringRenderer : MonoBehaviour
{
    SpringJoint2D spring;
    LineRenderer lineRenderer;

    void Start()
    {
        this.spring = GetComponent<SpringJoint2D>();
        this.lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRenderer.enabled = spring.enabled && spring.connectedBody != null;
        if (!lineRenderer.enabled) return;
        var a = spring.connectedBody.transform.position + spring.connectedBody.transform.TransformVector(spring.connectedAnchor);
        var b = gameObject.transform.position;
        lineRenderer.SetPosition(0, a);
        lineRenderer.SetPosition(1, b);
    }
}

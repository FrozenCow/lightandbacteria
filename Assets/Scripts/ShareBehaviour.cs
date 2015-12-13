using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CellBehaviour))]
public class ShareBehaviour : MonoBehaviour
{
    CellBehaviour cellBehaviour;
    public float shareRate = 1.0f;
    void Start()
    {
        cellBehaviour = GetComponent<CellBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        HandleCollision(collision);
    }

    private void HandleCollision(Collision2D collision)
    {
        var otherCell = collision.gameObject;
        var otherCellBehaviour = otherCell.GetComponent<CellBehaviour>();
        if (otherCellBehaviour == null) return;
        var sharableSize = cellBehaviour.size - otherCellBehaviour.size;
        if (sharableSize <= 0) return;
        sharableSize = Mathf.Max(sharableSize, shareRate * Time.deltaTime);
        cellBehaviour.Grow(-sharableSize);
        otherCellBehaviour.Grow(sharableSize);
    }
}

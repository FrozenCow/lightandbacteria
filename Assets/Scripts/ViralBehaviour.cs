using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

[RequireComponent(typeof(CellBehaviour))]
public class ViralBehaviour : MonoBehaviour
{
    CellBehaviour cellBehaviour;
    public float delay = 0.2f;
    private float startTime;
    public string[] infectTags;

    public void Start()
    {
        cellBehaviour = GetComponent<CellBehaviour>();
        startTime = Time.time;
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
        if (Time.time < startTime + delay) return;
        var otherCellBehaviour = otherCell.GetComponent<CellBehaviour>();
        if (otherCellBehaviour == null) return;
        if (!infectTags.Contains(otherCell.tag)) return;
        var newCell = cellBehaviour.Clone();
        if (newCell == null) return;
        otherCell.SetActive(false);
        newCell.transform.parent = otherCell.transform.parent;
        newCell.transform.localPosition = otherCell.transform.localPosition;
        newCell.transform.localRotation = otherCell.transform.localRotation;
        newCell.transform.localScale = otherCell.transform.localScale;
        newCell.GetComponent<CellBehaviour>().size = otherCellBehaviour.size;
        Destroy(otherCell);
    }
}

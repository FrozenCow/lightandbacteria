using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Light))]
public class CellGrowBehaviour : MonoBehaviour
{
    public float growthRate = 2;
    private List<GameObject> OverlappingCells = new List<GameObject>();
    new Light light;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        List<GameObject> destroyedCells = new List<GameObject>();
        foreach(var cell in OverlappingCells)
        {
            if (cell == null)
            {
                destroyedCells.Add(cell);
                continue;
            }
            var cellBehaviour = cell.GetComponent<CellBehaviour>();
            if (cellBehaviour != null)
                cellBehaviour.Grow(Time.deltaTime * growthRate);
        }
        foreach (var destroyedCell in destroyedCells)
        {
            OverlappingCells.Remove(destroyedCell);
        }

        light.range = 5 + growthRate;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        OverlappingCells.Add(collision.gameObject);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        OverlappingCells.Remove(collision.gameObject);
    }
}

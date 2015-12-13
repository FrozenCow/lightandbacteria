using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LessThanCondition : MonoBehaviour, ICondition {
    private Image image;
    public string cellTag;
    public int maxCount = 0;
    private bool isValid;
    public bool IsValid()
    {
        return isValid;
    }

    public bool IsFailing()
    {
        return false;
    }

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void Update()
    {
        isValid = CellCounter.GetCount(cellTag) <= maxCount;
        image.enabled = isValid;
    }
}

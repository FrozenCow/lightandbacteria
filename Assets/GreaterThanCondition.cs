using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class GreaterThanCondition : MonoBehaviour, ICondition
{
    public string cellTag;
    public int minCount = 100;
    public Sprite successSprite;
    public Sprite failedSprite;
    private bool isValid;
    private bool isFailing;

    Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public bool IsValid()
    {
        return isValid;
    }

    public bool IsFailing()
    {
        return isFailing;
    }

    public void Update()
    {
        var count = CellCounter.GetCount(cellTag);
        isValid = count >= minCount;
        isFailing = count == 0;
        image.sprite = isValid
            ? successSprite
            : isFailing
            ? failedSprite
            : null;
        image.enabled = image.sprite != null;
    }
}
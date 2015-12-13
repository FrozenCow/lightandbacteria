using UnityEngine;
using System.Collections;
using System.Linq;
public class GoalManager : MonoBehaviour {
    private bool isValid = false;
    public CanvasGroup winCanvas;
    public CanvasGroup failCanvas;

    void Update () {
        var conditions = GetComponentsInChildren<GreaterThanCondition>().Cast<ICondition>()
            .Concat(GetComponentsInChildren<LessThanCondition>());
        isValid = isValid
            || conditions.All(condition => condition.IsValid())
            || Input.GetKeyDown(KeyCode.L);
        bool isFailing = !isValid && conditions.Any(condition => condition.IsFailing());
        if (winCanvas != null && isValid != winCanvas.interactable)
        {
            winCanvas.interactable = isValid;
            winCanvas.alpha = isValid ? 1 : 0;
            winCanvas.blocksRaycasts = isValid;
        }
        else if (failCanvas != null && isFailing != failCanvas.interactable)
        {
            failCanvas.interactable = isFailing;
            failCanvas.alpha = isFailing ? 1 : 0;
            failCanvas.blocksRaycasts = isFailing;
        }
    }
}

using UnityEngine;
using System.Collections;

public class RestartSceneButton : MonoBehaviour {

    public void OnClick()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}

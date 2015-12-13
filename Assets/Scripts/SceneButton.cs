using UnityEngine;
using System.Collections;
using System;

public class SceneButton : MonoBehaviour
{
    public string sceneName;
    public void OnClick()
    {
        if (String.IsNullOrEmpty(sceneName))
            Application.LoadLevel(Application.loadedLevel + 1);
        else
            Application.LoadLevel(sceneName);
    }
}

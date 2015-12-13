using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CounterText : MonoBehaviour {
    Text text;
    public string countTag;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "(" + CellCounter.GetCount(countTag).ToString() + ")";
	}
}

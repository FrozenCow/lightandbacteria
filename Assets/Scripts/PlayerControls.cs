using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {
    public CellGrowBehaviour cellGrowBehaviour;
    public float power = 10.0f;
    public float maxPower = 10.0f;
    public float powerUseRate = 2.0f;
    public float powerGainRate = 3.0f;
    public float growthRate = 5;
    private bool isUsing = false;
	void Start () {
	
	}
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
            isUsing = true;
        if (isUsing && Input.GetMouseButton(0) && power > 0)
        {
            cellGrowBehaviour.growthRate = growthRate;
            power -= powerUseRate * Time.deltaTime;
        }
        else
        {
            isUsing = false;
            cellGrowBehaviour.growthRate = 0;
            power += powerGainRate * Time.deltaTime;
            if (power > maxPower)
                power = maxPower;
        }
    }
}

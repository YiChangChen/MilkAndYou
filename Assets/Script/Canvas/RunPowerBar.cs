using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RunPowerBar : MonoBehaviour
{ 
    public Slider runpower;
    public GameObject target;
    public float RunPowerBarPositionOffset;
    //public Animator animator;

    public float timing;
    public float Delay = 2;
    //public int MaxPower;
    //public int curPower;
    //public int Power = 10;

	// Use this for initialization
	void Start () {
        //animator = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector2 targetSP = Camera.main.WorldToScreenPoint(target.transform.position);
        runpower.GetComponent<RectTransform>().position = targetSP + Vector2.up * RunPowerBarPositionOffset;
        //SetPower(run);
	}

    public void SetPower(int power)
    {
        timing += Time.deltaTime;
        if (timing >= Delay)
        {
            timing = 0;
            if(runpower.value <= (float)100)
            {
                runpower.value += power;
            }
        }
    }
}

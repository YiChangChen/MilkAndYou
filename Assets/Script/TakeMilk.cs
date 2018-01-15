using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeMilk : MonoBehaviour {

    public Slider MPBar;
    public float milkPower;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision catchMilk)
    {
        Debug.Log("觸發");
        GameObject hit = catchMilk.gameObject;
        Debug.Log(hit);
        if (hit.tag == "Player")
        {
            Destroy(gameObject);
            if (MPBar.value < 100)
            {
                MPBar.value += milkPower;
            }
        }
    }
}

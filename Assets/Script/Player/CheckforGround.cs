using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforGround : MonoBehaviour {

    public Animator animator;
    RaycastHit hit;

    //public GameObject player;
    [Header("是否站在地面")]
    public bool isGround;
    [Header("跳躍力量")]
    public float jumpOffset = 400f;
    
    
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        //player = GetComponent<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateState();
    }

    void UpdateState()
    {
        float Raydistance;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Raydistance = transform.position.y - hit.point.y;
            //Debug.Log(Raydistance);
            if(Raydistance > 0.25f)
            {
                Debug.DrawLine(transform.position, hit.point, Color.green, 0.01f, false);
                isGround = false;
                animator.SetBool("jump", false);
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.green, 0.01f, false);
                isGround = true;
            }
        }
    }

    void JumpBtnClick()
    {
        if (isGround)
        {
            animator.SetBool("jump", true);
            GetComponent<Rigidbody>().AddForce(0, jumpOffset, 0);
        }
        //animator.SetBool("jump", false);
    }

}

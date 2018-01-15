using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforGround : MonoBehaviour {

    //public GameObject player;
    public bool isGround;
    public Animator animator;
    //public float hitdistance;
    //public LayerMask layer;
    RaycastHit hit;
    public float jumpOffset = 400f;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        //player = GetComponent<GameObject>();
        //UpdateState();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateState();
    }

    public void UpdateState()
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
        //if (isGround)
        //{
        //    hitdistance = 0.35f;
        //}
        //else
        //{
        //    hitdistance = 0.15f;
        //}
        //if (Physics.Raycast(transform.position - new Vector3(0, 0.35f, 0), -transform.up, hitdistance, layer))
        //{
        //    Debug.DrawLine(transform.position, hit.point, Color.green, 0.01f, false);
        //    isGround = true;
        //}
        //else
        //{
        //    isGround = false;
        //}
    }
    public void JumpBtnClick()
    {
        if (isGround)
        {
            animator.SetBool("jump", true);
            GetComponent<Rigidbody>().AddForce(0, jumpOffset, 0);
        }
        //animator.SetBool("jump", false);
    }

}

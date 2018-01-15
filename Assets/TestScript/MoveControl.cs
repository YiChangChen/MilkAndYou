using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MoveControl : MonoBehaviour {
    public CharacterController controller;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    public float speed = 6.0F;
    public float moveOffset = 0.0f;
    public float jumpOffset = 0.0f;


    [System.Serializable]
    public class AnimatorParameters
    {
        public string Moving;
        public string Jumping;
        //public string Horizotal;
        //public string Vertical;
    }

    public Animator target;
    //public float speed = 2.5f;
    public AnimatorParameters parameters;

    //private Vector3 direction;
    private Coroutine cououtine;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        //speed = 0;
    }

   // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X right and left
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //Y 
        moveVector.y = verticalVelocity;
        //Z 
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

    }

    public void ClickUpBtn()
    {
        moveVector.x = -moveOffset * speed;
        controller.Move(moveVector * Time.deltaTime);
    }

    public void ClickDownBtn()
    {
        moveVector.x = moveOffset * speed;
        controller.Move(moveVector * Time.deltaTime);
    }

    public void ClickJumpBtn()
    {
        if (controller.isGrounded)
        {
            verticalVelocity = jumpOffset * Time.deltaTime;
        }
        moveVector.y = verticalVelocity;

        controller.Move(moveVector * Time.deltaTime);
    }

    private IEnumerator Move()
    {
        while (true)
        {
            //this.target.transform.position += this.direction * Time.deltaTime * this.speed;

            //this.target.SetFloat(this.parameters.Horizotal, this.direction.x);
            //this.target.SetFloat(this.parameters.Vertical, this.direction.y);

            //this.controller.transform.LookAt(new Vector3(this.controller.transform.position.z - this.moveVector.y * 60, this.controller.transform.position.y, this.controller.transform.position.x + this.moveVector.x * 60));
            this.target.transform.LookAt(new Vector3(this.target.transform.position.z - this.moveVector.y * 60, this.target.transform.position.y, this.target.transform.position.x + this.moveVector.x * 60));
            if(controller.isGrounded)
            {
                //this.controller.transform.Translate(Vector3.forward * Time.deltaTime * speed);
                this.target.transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
            yield return null;
        }
    }

    public void BeginMove()
    {
        
        this.target.SetBool(this.parameters.Moving, true);
        this.cououtine = StartCoroutine(this.Move());
    }

    public void EndMove()
    {
        this.target.SetBool(this.parameters.Moving, false);
        StopCoroutine(this.cououtine);
    }
    public void UpdateDirection(Vector3 moveVector)
    {
        this.moveVector = moveVector;
    }

    //public void JumpBtnClick()
    //{
    //    this.target.SetBool(this.parameters.Jumping, true);
    //    this.target.transform.LookAt(new Vector3(this.target.transform.position.x, this.target.transform.position.y, this.target.transform.position.z));
    //    this.target.transform.Translate(Vector3.forward * Time.deltaTime * speed);
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {
  
    [System.Serializable]
    public class AnimatorParameters
    {
        public string walk;
        //public string Horizotal;
        //public string Vertical;
    }
    [System.Serializable]
    public class MoveParameters
    {
        public float speed = 2.5f;
    }

    public Animator target;
    //public float speed = 2.5f;
    public AnimatorParameters parameters;
    public MoveParameters MovingParameters;

    private Vector3 direction;
    private Coroutine cououtine;

    private IEnumerator Move()
    {
        while(true)
        {        
            this.target.transform.LookAt(new Vector3(this.target.transform.position.x - this.direction.y*60, this.target.transform.position.y, this.target.transform.position.z + this.direction.x * 60));
            this.target.transform.Translate(Vector3.forward * Time.deltaTime * MovingParameters.speed);
            yield return null;
        }
    }

    public void BeginMove()
    {
        this.target.SetBool(this.parameters.walk, true);
        this.cououtine = StartCoroutine(this.Move());
    }

    public void EndMove()
    {
        this.target.SetBool(this.parameters.walk, false);
        StopCoroutine(this.cououtine);
    }
    public void UpdateDirection(Vector3 direction)
    {
        this.direction = direction;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

    }
}

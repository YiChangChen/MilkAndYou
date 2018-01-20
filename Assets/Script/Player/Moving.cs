using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour {
  
    [System.Serializable]
    public class AnimatorParameters
    {
        public string walk;
    }
    public Animator target;
    public AnimatorParameters parameters;
    public GameObject RunBtn;
    public Slider slider;
    RunPowerBar RunPowerBar;
    RunBtnControl RunBtnControl;

    [Header("目前速度")]
    public float NowSpeed;
    [Header("跑步速度")]
    public float RunSpeed;
    [Header("走路速度")]
    public float WalkSpeed;
    [Header("消耗體力")]
    public int ConsumptionPower;
    [Header("回復體力")]
    public int AddPower;

    private Vector3 direction;
    private Coroutine cououtine;

    // Use this for initialization
    void Start()
    {
        RunPowerBar = slider.GetComponent<RunPowerBar>();
        RunBtnControl = RunBtn.GetComponent<RunBtnControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }


    private IEnumerator Move()
    {
        while(true)
        {
            this.target.transform.LookAt(new Vector3(this.target.transform.position.x - this.direction.y*60, this.target.transform.position.y, this.target.transform.position.z + this.direction.x * 60));
            this.target.transform.Translate(Vector3.forward * Time.deltaTime * NowSpeed);
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

    void Run()
    {
        if (RunBtnControl.runBtnParameters.isDown && slider.value > 0)
        {
            NowSpeed = RunSpeed;
            RunPowerBar.SetPower(ConsumptionPower);
            target.SetBool("run", true);
        }
        else
        {
            NowSpeed = WalkSpeed;
            RunPowerBar.SetPower(AddPower);
            target.SetBool("run", false);
        }
    }

}

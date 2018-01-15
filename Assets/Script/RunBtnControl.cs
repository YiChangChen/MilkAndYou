using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class RunBtnControl : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
    public Slider slider;
    public Animator animator;
    public GameObject PlayerControl;
    public int ConsumptionPower;
    public int AddPower;
    public float RunSpeed;
    public float WalkSpeed;
    RunPowerBar RunPowerBar;
    Moving moving;

    // 按鈕是否按下  
    bool isDown = false;

    // 延遲時間 
    public float delay = 1;

    //計時器
    public float timing;


    // Use this for initialization
    void Start()
    {
        RunPowerBar = slider.GetComponent<RunPowerBar>();
        moving = PlayerControl.GetComponent<Moving>();
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (isDown)
        {
            // 計時器 > 延遲時間 
            if (timing > delay)
            {
                Debug.Log("長按");
                timing = 0;
            }
        }
        //跑步
        Run();
    }

    //點擊按鈕
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
    }

    //滑鼠進入按紐
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Enter");
    }

    // 按鈕按住
    public void OnPointerDown(PointerEventData eventData)
    {
        isDown = true;
        timing = 0;
    }

    // 按鈕抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        isDown = false;
    }

    // 滑鼠離開按紐 
    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
    }

    void Run()
    {
        if(isDown && slider.value > 0)
        {
            RunPowerBar.SetPower(ConsumptionPower);
            moving.MovingParameters.speed = RunSpeed;
            animator.SetBool("run", true);
        }
        else
        {
            moving.MovingParameters.speed = WalkSpeed;
            RunPowerBar.SetPower(AddPower);
            animator.SetBool("run", false);
        }
    }
}

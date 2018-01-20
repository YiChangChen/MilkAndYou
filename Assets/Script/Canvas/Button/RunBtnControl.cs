using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class RunBtnControl : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IEventSystemHandler
{
    [System.Serializable]
    public class RunBtnParameters
    {
        [Header("按鈕是否按下")]
        public bool isDown = false;
    }

    public RunBtnParameters runBtnParameters;

    // 按鈕是否按下  
    //bool isDown = false;

    [Header("判斷為長按的時間間距")]
    public float delay = 1;

    //計時器
    private float timing;


    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        timing += Time.deltaTime;
        if (runBtnParameters.isDown)
        {
            // 計時器 > 延遲時間 
            if (timing > delay)
            {
                Debug.Log("長按");
                timing = 0;
            }
        }
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
        runBtnParameters.isDown = true;
        timing = 0;
    }

    // 按鈕抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        runBtnParameters.isDown = false;
    }

    // 滑鼠離開按紐 
    public void OnPointerExit(PointerEventData eventData)
    {
        runBtnParameters.isDown = false;
    }
}

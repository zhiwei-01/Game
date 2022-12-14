using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [HideInInspector]
    public bool isBlack = false;//不透明

    [HideInInspector]
    public float fadeSpeed = 0.5f;//淡入淡出速度
    public RawImage rawImage;
    public RectTransform rectTransform;


    void Start()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);//讓背景滿屏
        rawImage.color = Color.clear;
    }

    
    void Update()
    {
        if (isBlack == false)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);//漸漸亮
            
            if (rawImage.color.a < 0.1f)
            {
                rawImage.color = Color.clear;
            }
        }
        else if (isBlack)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.black, Time.deltaTime * fadeSpeed);//漸漸暗
            if (rawImage.color.a > 0.9f)
            {
                rawImage.color = Color.black;
            }
        }

            

        }


    

    //切换狀態
    public void BackGroundControl(bool b)
    {
        if (b == true)
            isBlack = true;
        else
            isBlack = false;
        
    }
}

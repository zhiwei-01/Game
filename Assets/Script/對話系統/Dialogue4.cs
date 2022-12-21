using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue4 : MonoBehaviour
{
    [Header("像素角色 + 鏡頭")]
    public GameObject 像素人;
    public GameObject 鏡頭;

    [Header("目前狀態")]
    public GameObject 目前場景;
    public GameObject 下個場景;

    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;
   
    
    [Header("文字腳本4")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    public GameObject tip;

    [Header("角色")]
    public Sprite 旁00;
    public Sprite 主15;
    public Sprite 主18;
    public Sprite 主19;
    public Sprite 主20;
    public Sprite 媽21;
    public Sprite 媽22;
    public Sprite 媽23;
    public Sprite 媽24;


    bool textFinished;//是否完成打字
    bool cancelTyping;//取消打字

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);
    }
    
    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(SetTextUI());
        像素人.SetActive(true);
        //鏡頭.transform.localPosition = new Vector3 ( -5.4f , 0.45f , -5f );
    }

    void Update()
    {
        if( index == textList.Count)
        {
            目前場景.SetActive(false);
            下個場景.SetActive(true);
            index = 0;
            return;

        }
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if(!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }

        if(index == 2)
        {
            tip.SetActive(true);
        }
        else
        {
            tip.SetActive(false);
        }

      

    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineDate = file.text.Split('\n');

        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false; //代表正在輸出
        textLabel.text = "";

        switch (textList[index].Trim().ToString())

        {

            case "旁":
                faceImage.sprite = 旁00;
                index++;
                break;

            case "主18":
                faceImage.sprite = 主18;
                index++;
                break;

            case "主19":
                faceImage.sprite = 主19;
                index++;
                break;

            case "主20":
                faceImage.sprite = 主20;
                index++;
                break;

            case "主15":
                faceImage.sprite = 主15;
                index++;
                break;

            case "媽21":
                faceImage.sprite = 媽21;
                index++;
                break;

            case "媽22":
                faceImage.sprite = 媽22;
                index++;
                break;

            case "媽23":
                faceImage.sprite = 媽23;
                index++;
                break;

            case "媽24":
                faceImage.sprite = 媽24;
                index++;
                break;

        }



        int letter = 0;
        while(!cancelTyping && letter < textList[index].Length-1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;//輸出完畢
        index++;


    }
    public void 點擊按鈕()
    {
        index = 39;
    }
}

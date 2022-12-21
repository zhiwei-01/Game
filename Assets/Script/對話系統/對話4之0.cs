using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 對話4之0 : MonoBehaviour
{
    [Header("目前狀態")]
    public GameObject 目前場景;
    public GameObject 下個場景;
    public GameObject 控制畫布;
    public GameObject 控制過場;
    public Animator 過場;

    [Header("像素角色 + 鏡頭")]
    public GameObject 像素人;
    public GameObject 鏡頭;

    [Header("UI組件")]
    public Text textLabel;
    public Image 畫面;


    [Header("文字腳本4")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    public GameObject tip;

    [Header("角色")]
    public Sprite 主角反駁;
    public Sprite 媽媽訓話;

    bool textFinished;//是否完成打字
    bool cancelTyping;//取消打字

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);
        控制過場.SetActive(false);
    }

    private void OnEnable()
    {
        textFinished = true;
        StartCoroutine(SetTextUI());

    }

    void Update()
    {
        if (index == textList.Count)
        {
            目前場景.SetActive(false);
            下個場景.SetActive(true);
            index = 0;
            return;
        }

        if (index == 12) 
        {
            像素人.SetActive(false);
            鏡頭.transform.localPosition = new Vector3(-5.4f, 0.45f, -5f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }

        if (index == 2)
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

        foreach (var line in lineDate)
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
                控制畫布.SetActive(false);
                index++;
                break;

            case "主":
                控制畫布.SetActive(true);
                畫面.sprite = 主角反駁;
                index++;
                break;

            case "媽":
                控制畫布.SetActive(true);
                畫面.sprite = 媽媽訓話;
                index++;
                break;

            case "過場":
                控制過場.SetActive(true);
                過場.SetBool("是否要過場",true);
                index++;
                break;

        }

        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length - 1)
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
        index = 13;
        像素人.SetActive(false);
        鏡頭.transform.localPosition = new Vector3(-5.4f, 0.45f, -5f);
    }

}


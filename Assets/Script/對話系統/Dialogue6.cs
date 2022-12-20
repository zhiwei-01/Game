using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue6 : MonoBehaviour
{
    [Header("要隱藏的UI")]
    public GameObject 打鬥UI;

    [Header("UI組件")]
    public Text textLabel;
    public Image 臉;
   
    
    [Header("文字腳本")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    public GameObject tip;

    [Header("角色")]
    public Sprite 旁白;
    public Sprite 主15;
    public Sprite 主16;
    public Sprite 主17;
    public Sprite 男25;
    public Sprite 男26;
    public Sprite 男28;

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
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && index == textList.Count) || (Input.GetKeyDown(KeyCode.Q) && index == textList.Count))
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q))
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
                臉.sprite = 旁白;
                index++;
                break;

            case "主15":
                臉.sprite = 主15;
                index++;
                break;

            case "主16":
                臉.sprite = 主16;
                index++;
                break;

            case "主17":
                臉.sprite = 主17;
                index++;
                break;

            case "男25":
                臉.sprite = 男25;
                index++;
                break;

            case "男26":
                臉.sprite = 男26;
                index++;
                break;

            case "男28":
                臉.sprite = 男28;
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

    public void 跳過劇情() 
    {
        index = 29 ;

        if (  index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
    }

}

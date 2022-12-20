using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue5 : MonoBehaviour
{
    [Header("要隱藏的其餘UI")]
    public GameObject 要隱藏的UI;
    public GameObject 目前劇情;

    [Header("UI組件")]
    public Text textLabel;
    public Image 畫面;
   
    
    [Header("文字腳本5")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    //public GameObject tip;

    [Header("角色")]
    public Sprite 旁白00;
    public Sprite 主角15;
    public Sprite 友人30;

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
        要隱藏的UI.SetActive(false);
    }

    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) && index == textList.Count) || (Input.GetKeyDown(KeyCode.Q) && index == textList.Count))
        {
            gameObject.SetActive(false);
            index = 0;
            SceneManager.LoadScene("街道打鬥");
            return;

        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Q))
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

        /*if(index == 2)
        {
            tip.SetActive(true);

        }
        else
        {
            tip.SetActive(false);
        }*/
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
                畫面.sprite = 旁白00;
                index++;
                break;

            case "友":
                畫面.sprite = 友人30;
                index++;
                break;

            case "主":
                畫面.sprite = 主角15;
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
        index = 26;
        if ( index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            SceneManager.LoadScene("街道打鬥");
            return;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue3 : MonoBehaviour
{
    [Header("UI組件")]
    public Text textLabel;
    public Image faceImage;
   
    
    [Header("文字腳本3")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;
    public GameObject tip;

    [Header("角色")]
    public Sprite face00,face02,face03,face05,face06,face07;

    bool textFinished;//是否完成打字
    bool cancelTyping;//取消打字

    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);       
    }
    
    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);
            index = 0;
            媽媽鎖鏈動畫.是否完成對話++;
            return;

        }

        /* if(Input.GetKeyDown(KeyCode.Space) && textFinished)//檢測當前行是否輸出完
        {
            
            StartCoroutine(SetTextUI());
        }*/

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

            case "A":

                faceImage.sprite = face00;

                index++;

                break;
            case "B":

                faceImage.sprite = face02;

                index++;

                break;

            case "C":

                faceImage.sprite = face03;

                index++;

                break;
            case "D":

                faceImage.sprite = face05;

                index++;

                break;
            case "E":

                faceImage.sprite = face06;

                index++;

                break;
            case "F":

                faceImage.sprite = face07;

                index++;

                break;

            

            

        }

        /*for(int i=0; i<textList[index].Length; i++ )
        {
            textLabel.text  += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }*/

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


    public void 點skip() 
    {
        gameObject.SetActive(false);
        index = 0;
        媽媽鎖鏈動畫.是否完成對話++;
        return;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class 翌日 : MonoBehaviour
{
    [Header("UI組件")]
    public GameObject 目前對話;
    public GameObject 下個對話;
    public TextMeshProUGUI  textLabel;

    [Header("文字腳本3")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    bool textFinished;//是否完成打字

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
        if (textFinished == true && index == textList.Count)
        {
            目前對話.SetActive(false);
            下個對話.SetActive(true);
            index = 0;
            return;
        }
        if (textFinished == true)
        {
            StartCoroutine(SetTextUI());
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (textFinished && !cancelTyping)
        //    {
        //        StartCoroutine(SetTextUI());
        //    }
        //    else if (!textFinished && !cancelTyping)
        //    {
        //        cancelTyping = true;
        //    }
        //}
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

        int letter = 0;
        while ( letter < textList[index].Length - 1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }

        textFinished = true; //輸出完畢
        index++;
    }

}

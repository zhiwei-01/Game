using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 主菜單 : MonoBehaviour
{
    [SerializeField] GameObject 選擇視窗;
    [SerializeField] GameObject 團隊視窗;

    public void 開始遊戲(string sceneName)
    {
        SceneManager.LoadScene("宣傳影片");
    }
    public void 回主選單(string sceneName)
    {
        SceneManager.LoadScene("主菜單");
    }
    public void 退出遊戲(string sceneName)
    {
        Application.Quit();
    }

    public void 繼續遊戲(string sceneName)
    {
        
    }

    public void 選項設定_開(string sceneName)
    {

        if (選擇視窗.activeSelf == false)
        {
            選擇視窗.SetActive(true);
        }

    }
    public void 選項設定_關(string sceneName)
    {
        if (選擇視窗.activeSelf == true)
        {
            選擇視窗.SetActive(false);
        }
    }

    public void 製作團隊_開(string sceneName)
    {
        if (團隊視窗.activeSelf == false)
        {
            團隊視窗.SetActive(true);
        }
    }

    public void 製作團隊_關(string sceneName)
    {
        if (團隊視窗.activeSelf == true)
        {
            團隊視窗.SetActive(false);
        }
    }

}

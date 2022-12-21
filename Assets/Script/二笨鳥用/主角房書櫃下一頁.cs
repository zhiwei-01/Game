using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 主角房書櫃下一頁 : MonoBehaviour
{
    public GameObject 下一頁按鈕狀態;
    public GameObject 書本狀態;
    public GameObject P_1;
    public GameObject P_2;
    public int 目前頁數 = 1;
    public int 總共頁數;

    void Start()
    {

    }

    private void OnEnable()
    {
        P_1.SetActive(true);
        P_2.SetActive(false);
        下一頁按鈕狀態.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
       /* if (目前頁數 == 1) 
        {
            P_1.SetActive(true);
            P_2.SetActive(false);
            下一頁按鈕狀態.SetActive(true);
        }*/
    }

    public void 下一頁() 
    {
        目前頁數++;

        switch (目前頁數) 
        {
            case 2:
                P_1.SetActive(false);
                P_2.SetActive(true);
                break;
        }

        if (目前頁數 == 總共頁數) 
        {
            下一頁按鈕狀態.SetActive(false);
        }
    }

    public void 關閉按鈕() 
    {
        書本狀態.SetActive(false);
        目前頁數 = 1;
    }

}

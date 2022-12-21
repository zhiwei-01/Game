using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 主角房書櫃打開 : MonoBehaviour
{

    public GameObject 當前按鈕狀態;
    public GameObject 書本;

    void Start()
    {
        
    }

    void Update()
    {
        揍下F鍵();
    }

    public void 揍下F鍵()
    {
        if (當前按鈕狀態.activeSelf == true && Input.GetKeyDown(KeyCode.F))
        {
            書本.SetActive(true);
        }
    }
}

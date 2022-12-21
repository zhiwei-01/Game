using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 主角房書櫃 : MonoBehaviour
{
    public GameObject 按鈕;

    void OnTriggerEnter2D(Collider2D A)
    {
        按鈕.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D A)
    {
        按鈕.SetActive(false);
    }

}

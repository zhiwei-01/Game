using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 藥水室書櫃顯示 : MonoBehaviour
{
    public GameObject 書櫃;

    void  OnTriggerStay2D (Collider2D A)
    {
        書櫃.SetActive(true);
    }
}

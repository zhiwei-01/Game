using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 二樓主角浴室碰撞 : MonoBehaviour
{
    public GameObject 碰撞;
    public Animator 動畫;

    void OnTriggerEnter2D(Collider2D A)
    {
        碰撞.SetActive(false) ;
        動畫.SetBool("是否開門",true);
    }

    void OnTriggerExit2D(Collider2D A) 
    {
        碰撞.SetActive(true);
        動畫.SetBool("是否開門", false);
    }

}

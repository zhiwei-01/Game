using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class 武器切換 : MonoBehaviour
{
    public SpriteResolver 武器;
    public Animator an;


    void Start()
    {
        an = GetComponent<Animator>();
    }  

    void Update()
    {
        武器觸發();
    }

    private void 武器觸發()
    {
        if (Input.GetMouseButtonDown(0))
        {
            武器.SetCategoryAndLabel("武器", "劍");
        }
        else if (Input.GetMouseButtonUp(0))
        {
            武器.SetCategoryAndLabel("武器", "棒");
        } 
 
        /* if (an.GetCurrentAnimatorStateInfo(0).IsName("Over"))
         {

         }*/


    }


}

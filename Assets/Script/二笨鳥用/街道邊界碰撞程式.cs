using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class 街道邊界碰撞程式 : MonoBehaviour
{
    public GameObject 劇情5;

    public void OnTriggerEnter2D(Collider2D A)
    {
           劇情5.SetActive(true);
    }

}

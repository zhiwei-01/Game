using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 雪花測試 : MonoBehaviour
{
    
  public Animator SnowAn;
  

  
    
    void Awake()
    {
      
      //an.SetActive(false);

    }

    
    void Update()
    {
      if (Input.GetKeyDown("e"))
        {
           SnowAn.SetBool("snow",true);
        }   

      else 
      {
          SnowAn.SetBool("snow",false);
      }
      /*if (Input.GetKeyDown("e"))
      {
        an.SetActive(true);
        Debug.Log("owo???????");
        
      } 
      else
      { 
        an.SetActive(false);
      }*/

      
    }
}

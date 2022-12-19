using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{

   public GameObject snowActtck;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey("e"))
        {
            snowActtck.SetActive(true);
        }
        else 
        {
            snowActtck.SetActive(false);
        }
    }
}

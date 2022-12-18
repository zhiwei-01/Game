using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class 媽媽鎖鏈動畫 : MonoBehaviour
{
    static public int 是否完成對話;

    public Animator 媽;
    public Animator 主角;
    // Start is called before the first frame update
    void Awake()
    {
        是否完成對話 = 0 ;
    }

    // Update is called once per frame
    void Update()
    {
        switch (是否完成對話) 
        {
            case 1:
                媽.SetBool("媽遷人", true);
                主角.SetBool("被媽遷", true);
                break;
        }
            
    }
}

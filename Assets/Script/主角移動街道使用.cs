using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 主角移動街道使用 : MonoBehaviour
{
    public float speed;
    public float jumpforce;//跳躍力度
    
    Rigidbody2D rd;
    Animator an;

    public bool isGround;//有沒有在地板
    public Transform checker;//檢查器的transform
    float checkRadius = 0.2f;//檢查器的範圍大小
    public LayerMask GroundLayer; //地板的圖層
    
    
   
  
    
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();   
         
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rd.velocity = Vector2.up*jumpforce;
            an.SetBool("isGround",false);
        }

       

    }

    private void FixedUpdate()//適合物理計算，固定頻率
    {
        isGround = Physics2D.OverlapCircle(checker.position,checkRadius,GroundLayer);        
        
        an.SetBool("isGround",isGround);

        float move = Input.GetAxis("Horizontal");
        float face = Input.GetAxisRaw("Horizontal");
        
        rd.velocity = new Vector2(speed*move,rd.velocity.y);

        an.SetFloat("move",Mathf.Abs(move));

        if(face !=0 )
        {
            transform.localScale = new Vector3(face,1,1);
            
        }
    }
}

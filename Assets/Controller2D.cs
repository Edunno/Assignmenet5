using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public Animator anim;
    private LayerMask environmentLayerMask;
    private LayerMask upgradeLayerMask;
    private bool FacingRight;
    private int jumpForce = 250;
    void Start()
    {
        environmentLayerMask = LayerMask.GetMask("Environment");
        upgradeLayerMask = LayerMask.GetMask("PowerUp");
    }

    void Update()
    {
        float hMove = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
        foreach(Touch touch in Input.touches)
        {
        if((touch.phase == TouchPhase.Began) && IsGrounded() && (touch.position.x > 1000) && (touch.position.x < 2000)){ //Screen.resolutions[0].width-(Screen.resolutions[0].width/4)
            Vector2 v = new Vector2(0,jumpForce);
            this.GetComponent<Rigidbody2D>().AddForce(v);
            jumpForce = 250;
        }
        if( IsGrounded() && (touch.position.x > 2000)){
            Vector2 v = new Vector2(2,this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Rigidbody2D>().velocity = v;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if( IsGrounded() && (touch.position.x < 1000)){
            Vector2 v = new Vector2(-2,this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Rigidbody2D>().velocity = v;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        }
        
        anim.SetFloat("Speed",hMove);
        if(GetComponent<Rigidbody2D>().velocity.y > 0.2){
            anim.SetBool("IsJumping",true);
        }
        if(GetComponent<Rigidbody2D>().velocity.y < -0.2){
            anim.SetBool("IsFalling",true);
        }
        if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.y)<0.2){
            anim.SetBool("IsJumping",false);
            anim.SetBool("IsFalling",false);
        }
        if(IsPowered()){
            jumpForce = 350;
        }
    }
    bool IsGrounded(){
        Vector2 pos = new Vector2(transform.position.x,transform.position.y);
        transform.rotation = Quaternion.identity;
        return Physics2D.Raycast(pos, Vector2.down, GetComponent<BoxCollider2D>().size.y,environmentLayerMask);
    }
    bool IsPowered(){
        GetComponent<Rigidbody2D>().IsTouchingLayers(upgradeLayerMask);
        Collider2D[] list = Physics2D.OverlapCircleAll(transform.position,0.4f);
        for(int i = 0;i<list.Length;i++){
            if(list[i].gameObject.layer == 9){
                Destroy(list[i].gameObject);
                return true;
            }
        }
        return false;
    }
}

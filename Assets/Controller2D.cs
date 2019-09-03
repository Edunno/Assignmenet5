using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    public Animator anim;
    private LayerMask environmentLayerMask;
    private bool FacingRight;
    void Start()
    {
        environmentLayerMask = LayerMask.GetMask("Environment");
    }

    void Update()
    {
        float hMove = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
        if(Input.GetKeyDown(KeyCode.W) && IsGrounded()){
            Vector2 v = new Vector2(0,250);
            this.GetComponent<Rigidbody2D>().AddForce(v);
        }
        if(Input.GetKey(KeyCode.D)&& IsGrounded()){
            Vector2 v = new Vector2(2,this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Rigidbody2D>().velocity = v;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(Input.GetKey(KeyCode.A)&& IsGrounded()){
            Vector2 v = new Vector2(-2,this.GetComponent<Rigidbody2D>().velocity.y);
            this.GetComponent<Rigidbody2D>().velocity = v;
            GetComponent<SpriteRenderer>().flipX = false;
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
    }
    bool IsGrounded(){
        Vector2 pos = new Vector2(transform.position.x,transform.position.y);
        transform.rotation = Quaternion.identity;
        return Physics2D.Raycast(pos, Vector2.down, GetComponent<BoxCollider2D>().size.y,environmentLayerMask);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    private LayerMask environmentLayerMask;
    void Start()
    {
        environmentLayerMask = LayerMask.GetMask("Environment");
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && IsGrounded()){
            Vector2 v = new Vector2(0,200);
            this.GetComponent<Rigidbody2D>().AddForce(v);
        }
    }
    bool IsGrounded(){
        Vector2 pos = new Vector2(transform.position.x,transform.position.y);
        return Physics2D.Raycast(pos, Vector2.down, GetComponent<BoxCollider2D>().size.y,environmentLayerMask);
    }
}

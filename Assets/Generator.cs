using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject player;
    public GameObject box;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nV = player.transform.position;
        print(nV);
        nV.y = nV.y-10; //How for down it looks from
        nV.x = nV.x+10; //How far out it looks
        if(Physics2D.RaycastAll(nV,Vector2.up).Length <=1){ //Check to see how many objects it finds
            Vector2 sV = new Vector2(Random.Range(1f,16f),0.1f); //Size of box
            box.transform.localScale = sV;
                nV.y = nV.y+10+Random.Range(-2f,2f); //Height difference
            Instantiate(box,new Vector3(nV.x,nV.y,0),Quaternion.identity);
        }
    }
}

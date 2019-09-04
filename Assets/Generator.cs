using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject player;
    public GameObject box;
    private float distPos = 1;
    private float distNeg = -1;
    private float genDist = 5;
    public GameObject jumpBoost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 nV = player.transform.position;
        if(nV.x/(genDist*distPos) > 1){
            distPos++;
            print(nV.x/genDist*distPos);
            Vector2 sV = new Vector2(Random.Range(1f,10f),0.1f); //Size of box
            nV.y = nV.y+Random.Range(-2f,1f); //Height difference
            GameObject box1 = Instantiate(box) as GameObject;
            box1.transform.position = new Vector3(genDist*distPos+Random.Range(-1f,3f),nV.y,0);
            box1.transform.localScale = sV;
            //Instantiate(box1,new Vector3(genDist*distPos+Random.Range(-1f,1f),nV.y,0),Quaternion.identity);
            Vector2 sV2 = new Vector2(Random.Range(1f,7f),0.1f);
            nV.y = nV.y+Random.Range(-2f,1f); //Height difference
            GameObject box2 = Instantiate(box) as GameObject;
            box2.transform.position = new Vector3(genDist*distPos+Random.Range(-3f,1f),nV.y,0);
            box2.transform.localScale = sV;
            
            GameObject upgrade = Instantiate(jumpBoost) as GameObject;
            upgrade.transform.position = new Vector3(genDist*distPos+Random.Range(-1f,2f),player.transform.position.y+5,0);
        }

        /* 
        Vector2 nV = player.transform.position;
        print(nV);
        nV.y = nV.y-10; //How for down it looks from
        nV.x = nV.x+10; //How far out it looks
        if(Physics2D.RaycastAll(nV,Vector2.up).Length <=1){ //Check to see how many objects it finds
            Vector2 sV = new Vector2(Random.Range(1f,16f),0.1f); //Size of box
            box.transform.localScale = sV;
                nV.y = nV.y+10+Random.Range(-2f,2f); //Height difference
            Instantiate(box,new Vector3(nV.x,nV.y,0),Quaternion.identity);
        }*/
    }
}

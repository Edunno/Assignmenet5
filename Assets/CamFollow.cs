using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Camera mCam;
    private float sizer = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RangeSizer());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nV = new Vector3(this.transform.position.x, this.transform.position.y, -5);
            mCam.GetComponent<Camera>().orthographicSize = 2 * sizer;
    mCam.transform.position = nV;
    }
    IEnumerator RangeSizer(){
        while (true){
            yield return new WaitForSeconds(0.01f);
            float x = Mathf.Abs(Input.GetAxisRaw("Horizontal"));
            if (x > 0 && sizer <1.5){
                sizer += 0.01f;
            }else if(sizer > 1 && x == 0){
                sizer -= 0.01f;
            }
        }
    }
}

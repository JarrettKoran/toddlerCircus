using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject c = GameObject.Find("Main Camera");
        Camera cam = c.GetComponent<Camera>();
        float aspect = cam.aspect;
        int height = cam.pixelHeight;
        int width = cam.pixelWidth;
        //Debug.Log("Width: " + width + "  Height: " + height + "  Aspect: " + aspect);
        //Debug.Log("local scale x: " + this.transform.localScale.x + "  local scale y: " + this.transform.localScale.y);
        /*this.transform.localScale = new Vector3(
            transform.localScale.x/aspect,
            transform.localScale.y/aspect,
            transform.localScale.z
        );*/
        //Debug.Log("local scale x: " + this.transform.localScale.x + "  local scale y: " + this.transform.localScale.y);
    }
	
}

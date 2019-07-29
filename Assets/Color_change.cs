using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_change : MonoBehaviour {

    MeshRenderer myRenderer;

    // Use this for initialization
    void Start () {
        myRenderer = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		myRenderer.material.color = Color.Lerp(Color.white, Color.blue, Mathf.Abs(myRenderer.transform.eulerAngles.z /360 - 1  ));
    }
}

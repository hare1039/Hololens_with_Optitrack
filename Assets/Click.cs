using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour {

    //List<GameObject> intList = new List<GameObject>();
    //GameObject father_;
    //public OptitrackRigidBodyCalibration button_push;
    public bool test = false;
    //intList = GameObject.transform.parent.gameObject;
    void OnSelect()
    {        
        Debug.Log("actually selected destroy");
        test = true;
    }
}

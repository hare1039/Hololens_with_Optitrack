using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.WSA.Persistence;

public class HololensCenter : MonoBehaviour {

	// Use this for initialization
	void Start () {

        InputTracking.Recenter();
    }

    void Update()
    {
        
    }


    void OnDrawGizmosSelected()
    {
        if (this.gameObject != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.forward);
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, 0.02f);
        }
    }
	
}

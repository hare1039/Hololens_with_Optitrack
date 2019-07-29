using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


[Serializable]
public class MyStringEvent : UnityEvent<String>
{
}

public class ButtonInfo : MonoBehaviour {

    public Vector2 PositionOnSphere;
    public Vector2 ButtonSize;
    public Material OriginalMaterial, ClickedMaterial;
    public MyStringEvent clickEvent;

    //For Commitment detect
    //Land on :Check whether the finger's position in the band
    //If the finger is in the band, then check is the button itself clicked(by trigger)
    //Take off: Check the finger's position, is it out of the band
    //If it enter the band then out of the band -> check which button is commit(by raycast)
    private Transform fingerTransform;
    private GameObject SphereUI;
    private const float bandWidth = 0.012f;
    private bool isClicked = false;
	private bool isTrigger = false;
	private String message = "";



	// Use this for initialization
	void Start () {
        
        //[Modify]
        fingerTransform = Finger.instance.gameObject.transform;

        if (ClickedMaterial == null)
        {
            ClickedMaterial = OriginalMaterial;
        }
		if(clickEvent == null)
			clickEvent = new MyStringEvent();
        this.GetComponent<Renderer>().material = OriginalMaterial;

	}
	
	// Update is called once per frame
	void Update () {
        //If the finger enter the band
        Vector3 fingerPosition = fingerTransform.position;
        Vector3 SphereCenter = SphereUI.transform.position;
        float SphereRadius = SphereUI.transform.localScale.x / 2.0f;
        //Enter the band-> Check whether the button is Trigger or not
        if (!fingerOutOfBand(fingerPosition, SphereCenter, SphereRadius))
        {
            if (isTrigger)
            {
                isClicked = true;
                this.GetComponent<Renderer>().material = ClickedMaterial;
            }
            else
            {
                //not commmit in takeoff selection interaction
                isClicked = false;
                this.GetComponent<Renderer>().material = OriginalMaterial;
            }
        }
        else if (isClicked)
        {
            //Take off selection commit
            this.GetComponent<Renderer>().material = OriginalMaterial;
            clickEvent.Invoke(message);
			isClicked = false;
        }
        
	}

    private bool fingerOutOfBand(Vector3 fingerPos, Vector3 center, float radius)
    {
        float fingerSurfaceDistance = Vector3.Distance(fingerPos, center) - radius;

        if (Mathf.Abs(fingerSurfaceDistance) > bandWidth)
            return true;
        return false;
    }

    public void setSphereUI(GameObject sphere)
    {
        this.SphereUI = sphere;
    }

	public void setMessage(String m)
	{
		message = m;
	}

	private void OnTriggerEnter(Collider other)
	{
		isTrigger = true;
	}

	private void OnTriggerExit(Collider other)
	{
		isTrigger = false;
	}

    public void refreshMaterial()
    {
        this.GetComponent<Renderer>().material = OriginalMaterial;
    }
}

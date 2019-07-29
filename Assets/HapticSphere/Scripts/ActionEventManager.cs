using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;

public class ActionEventManager : MonoBehaviour
{
    #region Singleton
    public static ActionEventManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    const float RADIUS_TO_SCALE_CONSTANS = 0.4898552f;

	public GameObject eyeCenter;
	public GameObject[] Sphere_UI;
	public GameObject[] ARView;
	public InputField searchBar; 

	private SphereData sphereData;

	private Vector3 Sphere4Rotation;
	private Vector3 SphereRight;
	private bool keyboardAppear = false;
	private float forwardAngle;

    void Start()
    {
        for (int i = 0; i < Sphere_UI.Length; i++)
        {
            Sphere_UI[i].SetActive(false);
        }
    }

	void Update()
	{
		for (int i = 0; i < Sphere_UI.Length; i++)
		{
			if (Sphere_UI[i].activeSelf)
			{
				//[Modify]
				Sphere_UI[i].transform.position = eyeCenter.transform.position + sphereData.center;
				//SphereUIs[i].transform.position = sphereData.center;
			}
		}

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector2 s = Sphere_UI[0].GetComponent<ButtonManagerApp>().Button[0].GetComponent<ButtonInfo>().ButtonSize;
            s.x += 0.2f; s.y += 0.2f;
            Sphere_UI[0].GetComponent<ButtonManagerApp>().setButtonSize(0, s);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 s = Sphere_UI[0].GetComponent<ButtonManagerApp>().Button[0].GetComponent<ButtonInfo>().ButtonSize;
            s.x -= 0.2f; s.y -= 0.2f;
            Sphere_UI[0].GetComponent<ButtonManagerApp>().setButtonSize(0, s);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector2 p = Sphere_UI[0].GetComponent<ButtonManagerApp>().Button[0].GetComponent<ButtonInfo>().PositionOnSphere;
            p.x += 0.2f;
            Sphere_UI[0].GetComponent<ButtonManagerApp>().setButtonPosition(0, p);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Vector2 p = Sphere_UI[0].GetComponent<ButtonManagerApp>().Button[0].GetComponent<ButtonInfo>().PositionOnSphere;
            p.x -= 0.2f;
            Sphere_UI[0].GetComponent<ButtonManagerApp>().setButtonPosition(0, p);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Vector2 p = Sphere_UI[0].GetComponent<ButtonManagerApp>().Button[0].GetComponent<ButtonInfo>().PositionOnSphere;
            p.y += 0.2f;
            Sphere_UI[0].GetComponent<ButtonManagerApp>().setButtonPosition(0, p);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Vector2 p = Sphere_UI[0].GetComponent<ButtonManagerApp>().Button[0].GetComponent<ButtonInfo>().PositionOnSphere;
            p.y -= 0.2f;
            Sphere_UI[0].GetComponent<ButtonManagerApp>().setButtonPosition(0, p);
        }
	}

	public void setUpSphereUIs(SphereData hSphere, float forwardAngle)
	{
		this.sphereData = hSphere;
		//[Modify]
		SphereRight = eyeCenter.transform.right;
		Vector3 hmdPosition = eyeCenter.transform.position;
		for (int i = 0; i < Sphere_UI.Length; i++)
		{
			Sphere_UI[i].transform.position = hmdPosition + sphereData.center;
			Sphere_UI[i].transform.localScale = 1.001f * (new Vector3(sphereData.radius / RADIUS_TO_SCALE_CONSTANS, sphereData.radius / RADIUS_TO_SCALE_CONSTANS, sphereData.radius / RADIUS_TO_SCALE_CONSTANS));
			Sphere_UI[i].transform.rotation = Quaternion.identity;
			Sphere_UI[i].transform.localEulerAngles = new Vector3(0, eyeCenter.transform.localEulerAngles.y, 0);
			Sphere_UI[i].GetComponent<SphereCollider>().enabled = false;
			Sphere_UI[i].GetComponent<ButtonManagerApp>().setUpButtons(forwardAngle);
			Sphere_UI[i].SetActive(true);
		}	
		this.forwardAngle = forwardAngle;
	}
}

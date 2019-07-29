//======================================================================================================
// Copyright 2016, NaturalPoint Inc.
//======================================================================================================
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;
using System.Linq;
using UnityEngine.XR.WSA.WebCam;
using UnityEngine.Assertions;






public class OptitrackRigidBodyCalibration : MonoBehaviour
{
    public OptitrackStreamingClient StreamingClient;
    public Int32 RigidBodyID;
    
    //public Click test;
    bool photo_show_flag = false;
    bool music_play = false;
    

    public Animator anim;


    //public Vector3 offsetRotation;

    private Matrix4x4 transformationMatrix;
    private bool matrixSet = false;
    OptitrackCalibration calibrationScript;

    // photos
    public GameObject obeject1;
    public GameObject obeject2;
    public GameObject obeject3;
    public GameObject obeject4;
    public GameObject object5;
    public GameObject object6;
    public GameObject object7;
    public GameObject object8;

    //photo text
    public GameObject object_text;

    // music text
    public GameObject m_text1;
    public GameObject m_text2;
    public GameObject m_text3;

    
    // music object
    public GameObject music1;
    public GameObject music2;
    public GameObject music3;


    void Start()
    {

        
        // If the user didn't explicitly associate a client, find a suitable default.
        if (this.StreamingClient == null)
        {
            this.StreamingClient = OptitrackStreamingClient.FindDefaultClient();

            // If we still couldn't find one, disable this component.
            if (this.StreamingClient == null)
            {
                //Debug.LogError(GetType().FullName + ": Streaming client not set, and no " + typeof(OptitrackStreamingClient).FullName + " components found in scene; disabling this component.", this);
                this.enabled = false;
                return;
            }
        }

        calibrationScript = GameObject.Find("Client - OptiTrack").GetComponent<OptitrackCalibration>();

        
        //Initialize Photos
        obeject1.gameObject.SetActive(false);
        obeject2.gameObject.SetActive(false);
        obeject3.gameObject.SetActive(false);
        obeject4.gameObject.SetActive(false);
        object5.gameObject.SetActive(false);
        object6.gameObject.SetActive(false);
        object7.gameObject.SetActive(false);
        object8.gameObject.SetActive(false);
        object_text.gameObject.SetActive(false);


        //Initialize Music
        music_play = false;
        music1.gameObject.SetActive(false);
        music2.gameObject.SetActive(false);
        music3.gameObject.SetActive(false);
        m_text1.gameObject.SetActive(false);
        m_text2.gameObject.SetActive(false);
        m_text3.gameObject.SetActive(false);

 
    }


    void Update()
    {
        OptitrackRigidBodyState rbState = StreamingClient.GetLatestRigidBodyState(RigidBodyID);
        Vector3 eulerAngles = this.transform.rotation.eulerAngles;

      
        
        

        if (rbState != null)
        {
            
            //assign the correct position
            if (matrixSet)
            {
                //Position
                CalibrationProcessData controllerData = calibrationScript.getControllerData();
                this.transform.localPosition = transformationMatrix.MultiplyPoint3x4(rbState.Pose.Position);
				
				//Rotation
				//Quaternion to Matrix4x4
				Matrix4x4 angleInMatrix = Matrix4x4.TRS(Vector3.zero, rbState.Pose.Orientation, Vector3.one);
				Matrix4x4 resultInMatrix = transformationMatrix * angleInMatrix;
                Quaternion q = QuaternionFromMatrix(resultInMatrix);
				//this.transform.rotation = q * Quaternion.Euler(offsetRotation.x, offsetRotation.y, offsetRotation.z);
                this.transform.rotation = q;

			}
            else
            {
                this.transform.localPosition = rbState.Pose.Position;
                this.transform.localRotation = rbState.Pose.Orientation;
                //Get the controller data
                if (calibrationScript.isDataInitiate() && !matrixSet)
                {
                    CalibrationProcessData controllerData = calibrationScript.getControllerData();
                    transformationMatrix = controllerData.PositiontransformationMatrix;
                    matrixSet = true;
                }
            }
           
            Debug.Log("transform.rotation angles x: " + eulerAngles.x + " y: " + eulerAngles.y + " z: " + eulerAngles.z);
            
        }

        
        //if Pen's angel in this range , it can show photos  
        if(this.transform.rotation.eulerAngles.y > 250 && this.transform.rotation.eulerAngles.y < 290 )
        {
            photo_show_flag = true;
        }
        else
        {
          
            photo_show_flag = false;
           
            obeject1.gameObject.SetActive(false);
            obeject2.gameObject.SetActive(false);
            obeject3.gameObject.SetActive(false);
            obeject4.gameObject.SetActive(false);
            object5.gameObject.SetActive(false);
            object6.gameObject.SetActive(false);
            object7.gameObject.SetActive(false);
            object8.gameObject.SetActive(false);
            object_text.gameObject.SetActive(false);
        }

        //if Pen's angel in this range , it can listen music  
        if ((this.transform.rotation.eulerAngles.y < 20 || this.transform.rotation.eulerAngles.y > 340) && this.transform.rotation.eulerAngles.x > 290)
        {
            music_play = true;
        }
        else 
        {
           
            music_play = false;
            music1.gameObject.SetActive(false);
            music2.gameObject.SetActive(false);
            music3.gameObject.SetActive(false);
            m_text1.gameObject.SetActive(false);
            m_text2.gameObject.SetActive(false);
            m_text3.gameObject.SetActive(false);

        }



        //play music
        if(music_play)
        {
            //play 1st music
            if (this.transform.rotation.eulerAngles.z < 120)
            {
                music1.gameObject.SetActive(true);
                music2.gameObject.SetActive(false);
                music3.gameObject.SetActive(false);
                Debug.Log("0000000000");
                m_text1.gameObject.SetActive(true);
                m_text2.gameObject.SetActive(false);
                m_text3.gameObject.SetActive(false);
            }
            //play 2nd music
            else if (this.transform.rotation.eulerAngles.z > 120 && this.transform.rotation.eulerAngles.z <240)
            {
                music1.gameObject.SetActive(false);
                music2.gameObject.SetActive(true);
                music3.gameObject.SetActive(false);
                Debug.Log("1111111111111");
                m_text1.gameObject.SetActive(false);
                m_text2.gameObject.SetActive(true);
                m_text3.gameObject.SetActive(false);
            }
            //play 3rd music
            else
            {
                music1.gameObject.SetActive(false);
                music2.gameObject.SetActive(false);
                music3.gameObject.SetActive(true);
                Debug.Log("222222222222");
                m_text1.gameObject.SetActive(false);
                m_text2.gameObject.SetActive(false);
                m_text3.gameObject.SetActive(true);
            }
        }
        
        
        

        // Show Photos
        if(photo_show_flag)
        {

            object_text.gameObject.SetActive(true);
            //Show Photo 1
            if (this.transform.rotation.eulerAngles.z < 45)
            {   
               
                
                obeject1.gameObject.SetActive(true);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(false);
                
            }
            //Show Photo 2
            else if (this.transform.rotation.eulerAngles.z >= 45 && this.transform.rotation.eulerAngles.z < 90)
            {
               
                
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(true);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(false);
                
            }
            //Show Photo 3
            else if (this.transform.rotation.eulerAngles.z >= 90 && this.transform.rotation.eulerAngles.z < 135)
            {
                
            
                
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(true);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(false);
              
            }
            //Show Photo 4
            else if (this.transform.rotation.eulerAngles.z >= 135 && this.transform.rotation.eulerAngles.z < 180)
            {
                
                
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(true);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(false);
                
            }
            //Show Photo 5
            else if (this.transform.rotation.eulerAngles.z >= 180 && this.transform.rotation.eulerAngles.z < 225)
            {
              
                
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(true);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(false);
               
            }
            //Show Photo 6
            else if (this.transform.rotation.eulerAngles.z >= 225 && this.transform.rotation.eulerAngles.z < 270)
            {
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(true);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(false);
              
            }
            //Show Photo 7
            else if (this.transform.rotation.eulerAngles.z >= 270 && this.transform.rotation.eulerAngles.z < 315)
            { 
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(true);
                object8.gameObject.SetActive(false);
               
            }
            //Show Photo 8
            else
            {
                
                obeject1.gameObject.SetActive(false);
                obeject2.gameObject.SetActive(false);
                obeject3.gameObject.SetActive(false);
                obeject4.gameObject.SetActive(false);
                object5.gameObject.SetActive(false);
                object6.gameObject.SetActive(false);
                object7.gameObject.SetActive(false);
                object8.gameObject.SetActive(true);
               
            }

            
                
        }
       
        
    }

 

    private Vector3 processAngle(Vector3 angle)
    {
        Vector3 result = new Vector3(angle.x,angle.y,angle.z);
        for (int i = 0; i < 3; i++)
            if (result[i] > 180 ) result[i] -= 360;
		for (int i = 0; i < 3; i++)
			if (result[i] < -180) result[i] += 360;
		return result;
    }

	private Quaternion QuaternionFromMatrix(Matrix4x4 m)
	{
		// Adapted from: http://www.euclideanspace.com/maths/geometry/rotations/conversions/matrixToQuaternion/index.htm
		Quaternion q = new Quaternion();
		q.w = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] + m[1, 1] + m[2, 2])) / 2;
		q.x = Mathf.Sqrt(Mathf.Max(0, 1 + m[0, 0] - m[1, 1] - m[2, 2])) / 2;
		q.y = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] + m[1, 1] - m[2, 2])) / 2;
		q.z = Mathf.Sqrt(Mathf.Max(0, 1 - m[0, 0] - m[1, 1] + m[2, 2])) / 2;
		q.x *= Mathf.Sign(q.x * (m[2, 1] - m[1, 2]));
		q.y *= Mathf.Sign(q.y * (m[0, 2] - m[2, 0]));
		q.z *= Mathf.Sign(q.z * (m[1, 0] - m[0, 1]));
		return q;
	}




   
}

    
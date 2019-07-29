using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

using UnityEngine.UI;

public class OptitrackCalibration : MonoBehaviour
{

    public enum CalibrationLoadMethod { LOADFILE, CALIBRATION, NONE };

    public CalibrationLoadMethod calibrateMethod;
    public OptitrackStreamingClient StreamingClient;
    public Int32 ControllerRigidbodyID;
    public GameObject ControllerGameobject;

    [Header("Debug")]
    public float delayStartCalibration = 0.1f;
    public Text calibrationInfoText;

    //Modify Here: [Marker Index]
    private const int MARKER_AMOUNT = 4;
    private CalibrationProcessData calibrationData = null;
    private bool dataInitiate = false;

    //The calibration will start after 1 second
    [SerializeField]
    private int samplingPoints = 1200;
    private bool sampling = false;
    private int samplingCount;

    //new 0524
    public GameObject generate_rbState_Objects_0; 
    public GameObject generate_ControllerGameobject_Objects_0;

    //public GameObject[] generate_rbState_Objects_1;
    //public GameObject[] generate_ControllerGameobject_Objects_1;




    // Use this for initialization
    void Start()
    {

        // If the user didn't explicitly associate a client, find a suitable default.
        if (this.StreamingClient == null)
        {
            this.StreamingClient = OptitrackStreamingClient.FindDefaultClient();

            // If we still couldn't find one, disable this component.
            if (this.StreamingClient == null)
            {
                Debug.LogError(GetType().FullName + ": Streaming client not set, and no " + typeof(OptitrackStreamingClient).FullName + " components found in scene; disabling this component.", this);
                this.enabled = false;
                return;
            }
        }

        calibrationData = new CalibrationProcessData();

        if (calibrateMethod == CalibrationLoadMethod.LOADFILE)
        {
            calibrationData.loadMatrixFromFile();
            dataInitiate = true;
        }

        else if (calibrateMethod == CalibrationLoadMethod.CALIBRATION)
        {
            print("Press C for calibration");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c") && (calibrateMethod == CalibrationLoadMethod.CALIBRATION) && !dataInitiate)
        {
            StartCoroutine(RunCalibration());
        }

        if (sampling)
        {
            OptitrackRigidBodyState rbState = StreamingClient.GetLatestRigidBodyState(ControllerRigidbodyID);

            if (rbState != null)
            {
                calibrationData.addPositionData(rbState.Pose.Position, ControllerGameobject.transform.position);
                samplingCount++;

                //new 0524

                
                Instantiate(generate_rbState_Objects_0, rbState.Pose.Position, Quaternion.identity);
                Instantiate(generate_ControllerGameobject_Objects_0, ControllerGameobject.transform.position, Quaternion.identity);
                
                
               
                


                // log some data
                Debug.Log(samplingCount + " - OptitrackRB: " + rbState.Pose.Position + ", GameObj: " + ControllerGameobject.transform.position);
                string path = "Assets/Resources/test.txt";
                //Write some text to the test.txt file
                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine(rbState.Pose.Position);
                writer.Close();


                if (samplingCount >= samplingPoints)
                {
                    sampling = false;
                    calibrationData.calibrateTransformationMatrix();
                    print("Finish Calibrate");
                    ShowCalibrationInfo("Finish Calibrate");
                    dataInitiate = true;

                    float error = 0.0f;
                    print("Calculating Error");
                    for (int i = 0; i < samplingCount; i++)
                    {
                        Vector3 temp = calibrationData.PositiontransformationMatrix.MultiplyPoint3x4(calibrationData.oriPosition[i]);

                        error += Vector3.Distance(temp, calibrationData.targetPosition[i]);
                    }
                    float errorMean = error / samplingCount;
                    Debug.Log(errorMean.ToString("F6"));
                    ShowCalibrationInfo("Calculating Error: " + errorMean.ToString("F6"));
                }

            }

        }

    }

    IEnumerator RunCalibration()
    {
        float t = Time.time;
        float nowTime = 0;
        while (nowTime < delayStartCalibration)
        {
            ShowCalibrationInfo("wait: " + (delayStartCalibration - nowTime).ToString("F1"));
            yield return new WaitForSeconds(0.1f);
            nowTime = Time.time - t;
        }

        samplingCount = 0;
        sampling = true;
        print("Start Calibration!");
        ShowCalibrationInfo("Start Calibration!");
    }

    void ShowCalibrationInfo(string s)
    {
        if (calibrationInfoText != null)
        {
            calibrationInfoText.text = s;
        }
    }

    public bool isDataInitiate()
    {
        return dataInitiate;
    }

    public CalibrationProcessData getControllerData()
    {
        return calibrationData;
    }
}

    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereGeneratorApp : MonoBehaviour
{
    /* ref : https://zh.scribd.com/document/14819165/Regressions-coniques-quadriques-circulaire-spherique
     */

    const float RADIUS_TO_SCALE_CONSTANS = 0.4898552f;

    //Scripts
    private CircumcentreSolver sphereSolver;
    private SpherePointVisualizer spherepointvisualizer;
    public Transform targetPosition;
    public GameObject eyeCenter;

    //Sphere Data
    private List<Vector3> points = new List<Vector3>();
    private SphereData hSphere = new SphereData(Vector3.zero, 0);
    [Range(0.1f, 5f)]
    public float defaultRadius = 0.35f;

    //Sampling Data
    private float timer = 0.0f;
    private bool onSampling = false;
    private const float samplingPeroid = 0.02f;

    //Visual Sphere
    private GameObject SphereUI;
	private float forwardAngle;

    void Start()
    {
        spherepointvisualizer = new SpherePointVisualizer();

        SphereUI = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        SphereUI.name = "SphereUI";
		SphereUI.GetComponent<Renderer>().enabled = false;
        SphereUI.SetActive(false);
    }

    void initSphereUI()
    {
        Vector3 hmdPosition = eyeCenter.transform.position;
        SphereUI.transform.position = hmdPosition + hSphere.center;
        SphereUI.transform.localScale = 1.001f * (new Vector3(hSphere.radius / RADIUS_TO_SCALE_CONSTANS, hSphere.radius / RADIUS_TO_SCALE_CONSTANS, hSphere.radius / RADIUS_TO_SCALE_CONSTANS));
        SphereUI.transform.rotation = Quaternion.identity;
        SphereUI.transform.localEulerAngles = new Vector3(0, eyeCenter.transform.localEulerAngles.y, 0);
        SphereUI.GetComponent<SphereCollider>().enabled = false;
        CalibrationButtons.instance.setButtons(SphereUI, hSphere.radius);
        SphereUI.SetActive(true);
    }

    void resetSphereUI()
    {
        print("Reset Sphere UI !");
        SphereUI.SetActive(false);
        points.Clear();

        timer = 0.0f;
    }


    void Update()
    {
        //[Modify]
         
        // For Sampling
        if (onSampling)
            PointsSampling();

        #region ComputerInputs
        
        //[Keyboard]
        //Start Sampling "Enter"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Start sampling!");
            //targetPosition.setUseHand();
            spherepointvisualizer.clear();
            onSampling = true;
        }

        //End Sampling "Enter"
        if (Input.GetKeyUp(KeyCode.Return))
        {
            print("End of sampling");
            onSampling = false;
            // apply offset to SphereUI

            if (points.Count > 0)
            {
                hSphere = ransac_sphere(points, 0.001f);
                ActionEventManager.instance.setUpSphereUIs(hSphere, forwardAngle);
                Destroy(SphereUI);
                //clear the points visualizer
                spherepointvisualizer.clear();
            }

        }
        
        //Set the user's facing angle and setup the inital sphere(SphereUI0) (HMD Case)
        if (Input.GetKeyDown(KeyCode.F))
        {
            //[Modify]
            forwardAngle = eyeCenter.transform.localEulerAngles.y;
            CalibrationButtons.instance.setForwardAngle(forwardAngle);
            resetSphereUI();
            hSphere.radius = defaultRadius;
            hSphere.center = Vector3.zero;

            initSphereUI();
        }
        
        //Load from Data "L"
        if (Input.GetKeyDown(KeyCode.L))
        {
            SphereData sphereload = SphereDataLoader.loadSphere();
            //There is a loading file
            if (sphereload.radius != -1)
            {
                hSphere = sphereload;
                ActionEventManager.instance.setUpSphereUIs(hSphere,forwardAngle);
                Destroy(SphereUI);
            }

        }
        //Save the current SphereUI data "S"
        if (Input.GetKeyDown(KeyCode.S))
            SphereDataWriter.writeSphereData(hSphere.center, hSphere.radius);
        
        #endregion
    }

    void PointsSampling()
    {
        timer += Time.deltaTime;

        if (timer >= samplingPeroid)
        {
            Vector3 indexTipPos = targetPosition.position;

            indexTipPos = indexTipPos - eyeCenter.transform.position;

            if ((indexTipPos.x != 0) || (indexTipPos.y != 0) || (indexTipPos.z != 0))
                points.Add(indexTipPos);
            timer = 0;

            spherepointvisualizer.visualizePoint(indexTipPos + eyeCenter.transform.position);
        }
    }

    #region CallBySpeechManager
    void OnFocus()
    {
        forwardAngle = eyeCenter.transform.localEulerAngles.y;
        CalibrationButtons.instance.setForwardAngle(forwardAngle);
        resetSphereUI();
        hSphere.radius = defaultRadius;
        hSphere.center = eyeCenter.transform.position;
        initSphereUI();
    }

    void OnStartSampling()
    {
        //print("Start sampling!");
        spherepointvisualizer.clear();
        onSampling = true;
    }

    void OnEndSampling()
    {
        onSampling = false;
        // apply offset to SphereUI

        if (points.Count > 0)
        {
            hSphere = ransac_sphere(points, 0.001f);
            ActionEventManager.instance.setUpSphereUIs(hSphere, forwardAngle);
            Destroy(SphereUI);
            //clear the points visualizer
            spherepointvisualizer.clear();
        }
    }
    #endregion 


    #region Math Functions

    SphereData ransac_sphere(List<Vector3> points, float tolerance)
    {
        // evaluate
        int maxVote = 0;
        SphereData bestSphere = null;

        for (int i = 0; i < 500; i++)
        {
            SphereData s = ransac_a_sphere(points);
            int vote = 0;
            foreach (Vector3 p in points)
            {
                float distance = Vector3.Distance(s.center, p);
                if (Mathf.Abs(distance - s.radius) < tolerance)
                    vote++;
            }

            if (maxVote < vote)
            {
                maxVote = vote;
                bestSphere = s;
            }
        }

        //output the SphereUI data
        print("Ransac: " + maxVote + "Matched / " + points.Count);
        print("Sphere: Center: " + bestSphere.center.x + " , " + bestSphere.center.y + " , " + bestSphere.center.z + "  " + " Radius: " + bestSphere.radius);
        print("Mean Error: " + calMeanError(points, bestSphere));
        print("Standard Error: " + calStdError(points, bestSphere));

        return bestSphere;
    }

    SphereData ransac_a_sphere(List<Vector3> points)
    {
        List<int> usedValues = new List<int>();
        int min = 0, max = points.Count;

        for (int i = 0; i < 4; i++)
        {
            int val = UnityEngine.Random.Range(min, max);
            while (usedValues.Contains(val))
                val = UnityEngine.Random.Range(min, max);
            usedValues.Add(val);
        }

        sphereSolver = new CircumcentreSolver(points[usedValues[0]], points[usedValues[1]], points[usedValues[2]], points[usedValues[3]]);
        return new SphereData(sphereSolver.Centre2, (float)(sphereSolver.Radius));
    }

    private float calMeanError(List<Vector3> points, SphereData s)
    {
        float total_error = 0f;

        for (int i = 0; i < points.Count; i++)
        {
            float distance = Vector3.Distance(s.center, points[i]);
            total_error += Mathf.Abs(distance - s.radius);
        }

        total_error /= points.Count;

        return total_error;
    }

    private float calStdError(List<Vector3> points, SphereData s)
    {
        float mean = calMeanError(points, s);
        float std = 0;

        for (int i = 0; i < points.Count; i++)
        {
            float difference = Mathf.Abs(Vector3.Distance(s.center, points[i]) - s.radius);
            std += (difference - mean) * (difference - mean);
        }

        std /= points.Count;

        std = Mathf.Sqrt(std);

        return std;

    }

    #endregion 
}

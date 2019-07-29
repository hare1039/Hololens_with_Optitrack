using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePointVisualizer : MonoBehaviour {

    GameObject parent;

    List<GameObject> points_sphere;

	// Use this for initialization
	/*void Start () {
        parent = new GameObject();
        parent.name = "ParentofPoints";
        resetparent();
        points_sphere = new List<GameObject>();
    }*/

    public SpherePointVisualizer()
    {
        parent = new GameObject();
        parent.name = "ParentofPoints";
        resetparent();
        points_sphere = new List<GameObject>();
    }
    

    // Update is called once per frame
    void Update () {

	}

    public void visualizePoint(Vector3 point)
    {
        GameObject point_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point_sphere.transform.position = point;
        point_sphere.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
        point_sphere.GetComponent<SphereCollider>().enabled = false;
        point_sphere.transform.parent = parent.transform;
        points_sphere.Add(point_sphere);
    }

    public void visualizePoint(Vector3 point, float scale, Material mat)
    {
        GameObject point_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point_sphere.transform.position = point;
        point_sphere.transform.localScale = new Vector3(scale, scale, scale);
        point_sphere.GetComponent<Renderer>().material = mat;
        point_sphere.transform.parent = parent.transform;
        points_sphere.Add(point_sphere);
    }

    public void visualizePoint(Vector3 point, float scale, Material mat, bool isStart)
    {
        GameObject point_sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        point_sphere.transform.position = point;
        point_sphere.transform.localScale = new Vector3(scale,scale,scale);
        point_sphere.GetComponent<Renderer>().material = mat;

        if (isStart)
        {
            point_sphere.tag = "Start";
            //point_sphere.GetComponent<SphereCollider>().radius = 1.3f;
        }
            
        else
        {
            point_sphere.tag = "End";
            //point_sphere.GetComponent<SphereCollider>().radius = 1.5f;
        }
            

        point_sphere.transform.parent = parent.transform;
        points_sphere.Add(point_sphere);
    }

    public void visualizePoint(List<Vector3> points,GameObject sphere)
    {
        
        for(int i = 0; i < points.Count; i++)
        {
            GameObject point = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            point.transform.position = points[i];
            point.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            point.transform.parent = parent.transform;
            points_sphere.Add(point);
        }
        parent.transform.parent = sphere.transform;

    }

    public void visualizePoint_Done(GameObject sphere)
    {
        parent.transform.parent = sphere.transform;
    }

    public void clear()
    {
        if(points_sphere != null)
        {
            while(points_sphere.Count > 0)
            {
                GameObject point = points_sphere[0];
                points_sphere.Remove(point);
                Destroy(point);
            }
            resetparent();
            
        }
    }

    void resetparent()
    {
        parent.transform.position = Vector3.zero;
        parent.transform.rotation = Quaternion.identity;
        parent.transform.localScale = new Vector3(1, 1, 1);
        parent.transform.parent = null;
    }

}

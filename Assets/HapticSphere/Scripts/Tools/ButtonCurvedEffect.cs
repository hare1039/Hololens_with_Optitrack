using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCurvedEffect : MonoBehaviour
{

    private GameObject SphereUI;

    private float button_length, button_height;
    public float angle_horizontal = 0, angle_vertical = 0;

    public GameObject pivot_point;

	public bool isDeepBtn = false;
	private float radiusOffset = 0.09f;

    public void setButton(GameObject SphereUI, float button_length, float button_height, float angle_vertical, float angle_horizontal)
    {
        this.SphereUI = SphereUI;
        this.button_length = button_length;
        this.button_height = button_height;
        this.angle_horizontal = angle_horizontal;
        this.angle_vertical = angle_vertical;

        //create the pivot point (for rotate the button horizontally)
        if(pivot_point == null)
            pivot_point = new GameObject();
        pivot_point.name = "pivot_point";
        
        button_curved_effect();
    }

    // Use this for initialization
    private void button_curved_effect()
    {
        //reset all the status
        pivot_point.transform.parent = null;
        this.transform.parent = null;
        pivot_point.transform.localRotation = this.transform.localRotation = Quaternion.identity;
        pivot_point.transform.position = this.transform.position = new Vector3(0, 0, 0);
        pivot_point.transform.localScale = this.transform.localScale = new Vector3(1, 1, 1);

        //set the pivot point (for rotate the button horizontally)
        SphereUI.transform.localRotation = Quaternion.identity;
        pivot_point.transform.position = SphereUI.transform.position;
        pivot_point.transform.parent = SphereUI.transform;

        //Attach the Plane on the Sphere
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3[] newvertices;
        newvertices = new Vector3[vertices.Length];
        int vertex_eachside = (int)Mathf.Sqrt(vertices.Length);
        float sphere_radius = isDeepBtn ? SphereUI.transform.localScale.x / 2.0f + radiusOffset : SphereUI.transform.localScale.x / 2.0f;

        Vector3 center = calculatepoint(angle_vertical, 0, sphere_radius);
        Vector2 ori_angles = calculateangle(-0.5f * button_length, 0.5f * button_height, angle_vertical, 0f, sphere_radius);
		//print("Ori_angles: " + ori_angles);
		

        for (int i = 0; i < vertex_eachside; i++)
        {
            for (int j = 0; j < vertex_eachside; j++)
            {
                float vertangles = ori_angles.x - (float)i / vertex_eachside * 2.0f * Mathf.Abs(ori_angles.x - angle_vertical);
                float horiangles = ori_angles.y + (float)j / vertex_eachside * 2.0f * Mathf.Abs(ori_angles.y - 0);
                Vector3 position = calculatepoint(vertangles, horiangles, sphere_radius);

                newvertices[i * vertex_eachside + j].x = position.x;
                newvertices[i * vertex_eachside + j].y = position.y;
                newvertices[i * vertex_eachside + j].z = position.z;


            }
        }

        mesh.vertices = newvertices;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateBounds();
        this.transform.parent = pivot_point.transform;
        pivot_point.transform.Rotate(Vector3.up, angle_horizontal, Space.Self);
        //this.GetComponent<MeshRenderer>().enabled = true;

    }

    public Vector3 calculatepoint(float vertical, float horizontal){
        return calculatepoint(vertical, horizontal, SphereUI.transform.localScale.x / 2.0f);
    }

    //calculate the position with the angle
    public Vector3 calculatepoint(float vertical, float horizontal, float radius)
    {
        float angle_theta = 90.0f - vertical;
        float angle_phi = horizontal;
        Vector3 center = new Vector3(0, 0, 0);
        Vector3 sphere_center = SphereUI.transform.position;

        center.x = sphere_center.x + radius * Mathf.Sin(angle_theta * Mathf.Deg2Rad) * Mathf.Cos(angle_phi * Mathf.Deg2Rad);
        center.z = sphere_center.z + radius * Mathf.Sin(angle_theta * Mathf.Deg2Rad) * Mathf.Sin(angle_phi * Mathf.Deg2Rad);
        center.y = sphere_center.y + radius * Mathf.Cos(angle_theta * Mathf.Deg2Rad);
        return center;
    }

    //calculate the corresponding angle with the relative position (to center)
    //x : vertical angle, y : horizontal angle
    Vector2 calculateangle(float length, float height, float vertical, float horizontal, float radius)
    {
        Vector2 result_angle = new Vector2(0, 0);

        //vertical angle
        float circle_perimeter = 2.0f * Mathf.PI * radius;
        result_angle.x = vertical + (height / circle_perimeter * 360f);

        //horizontal angle
        float subradius = radius * Mathf.Sin((90 - result_angle.x) * Mathf.Deg2Rad);
        float subperimeter = 2.0f * Mathf.PI * subradius;
        result_angle.y = horizontal + (length / subperimeter * 360f);

        return result_angle;
    }

    public Vector3 getButtonCenter()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;
        return this.gameObject.transform.TransformPoint(vertices[vertices.Length / 2]);
    }
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationButtons : MonoBehaviour
{

    #region Singleton
    public static CalibrationButtons instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    //Constants
	private const int HorizontalAmounts = 4;
	private const int VerticalAmounts = 3;
	private const int ButtonAmounts = HorizontalAmounts * VerticalAmounts;
	private const int VerticalAngle = -15;
	private const int HorizontalAngle = -90;

    //Button Space between
	public int VerticalRange = 30;
	public int HorizontalRange = 60;

	//Buttons varaible
	private GameObject[] Buttons;
	public Material button_material;
    [Range(0.01f, 0.05f)]
    public float button_Size;
	private float Button_Length;
	private float Button_Width;
	float forward_angle = 0;

	void Start()
	{
		Buttons = new GameObject[ButtonAmounts];
		for (int i = 0; i < ButtonAmounts; i++)
		{
			Buttons[i] = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Buttons[i].name = "Button_" + i;
			Buttons[i].transform.parent = this.transform;
			Buttons[i].AddComponent<ButtonCurvedEffect>();
			Buttons[i].GetComponent<Renderer>().material = button_material;
			Buttons[i].SetActive(false);
		}
	}

	public void setButtons(GameObject SphereUI, float Sphere_radius)
	{
        Button_Length = button_Size;
        Button_Width = button_Size;

		for (int i = 0; i < VerticalAmounts; i++)
		{
			for (int j = 0; j < HorizontalAmounts; j++)
			{
				int buttons_index = i * HorizontalAmounts + j;
				float angle_vertical = (VerticalRange / 2.0f) - ((float)VerticalRange / (float)(VerticalAmounts - 1) * i) + VerticalAngle;
				float angle_horizontal = ((float)HorizontalRange / (float)(HorizontalAmounts - 1) * j) - (HorizontalRange / 2.0f) + HorizontalAngle + forward_angle;
				Buttons[buttons_index].GetComponent<ButtonCurvedEffect>().setButton(SphereUI, Button_Length, Button_Width, angle_vertical, angle_horizontal);
				Buttons[buttons_index].SetActive(true);
			}

		}

	}

	public void setForwardAngle(float angle)
	{
		forward_angle = angle;
	}

}

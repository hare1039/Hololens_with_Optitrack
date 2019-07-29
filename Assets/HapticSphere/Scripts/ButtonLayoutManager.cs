using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLayoutManager{

    //ButtonManager 
    private ButtonManagerApp buttonManager;

    //Grid's unit length, angle
    private float buttonLength;
    private float buttonAngle;
    //Grid's Size
    private int GridWidth, GridHeight;
    
    //Sphere's data
    float radius;
    float forwardAngle;

    //Angle's Range and startPoint
    private const int VerticalAngle = 0;
    private const int HorizontalAngle = -90;
    private const int VerticalRange = 35;
    private const int HorizontalRange = 80;     

    public ButtonLayoutManager(ButtonManagerApp btM)
    {
        this.buttonManager = btM;
    }

    public void setUp(float length, float radius, float forwardAngle)
    {
        this.buttonLength = length;
        this.radius = radius;
        this.forwardAngle = forwardAngle;

        calculateGridSize();
        buttonAngle = LayoutCalculator.paritalAngle(buttonLength, radius);
        for (int i = 0; i < buttonManager.Button.Length; i++)
        {
            setUpButtonLayout(buttonManager.Button[i]);
        }
    }

    private void calculateGridSize()
    {
        float horizontalLength = LayoutCalculator.partialLength(HorizontalRange/2, radius);
        float verticalLength = LayoutCalculator.partialLength(VerticalRange/2, radius);

        GridWidth = (int)(horizontalLength / buttonLength) * 2;
        GridHeight = (int)(verticalLength / buttonLength) * 2;
    }

    public void setUpButtonLayout(GameObject button)
    {
        ButtonInfo buttonInfo = button.GetComponent<ButtonInfo>();
        Vector2 pos = buttonInfo.PositionOnSphere;
        Vector2 size = buttonInfo.ButtonSize;

        //calculate the button's center angle on sphere
        //It will be the mean off all the occupy grid
        List<Vector2> angleList = new List<Vector2>();
        for(int i = 0 ; i < size.y ; i++)
            for (int j = 0; j < size.x; j++)
            {
                Vector2 angle = Vector2.zero;

                angle.x = pos.x * buttonAngle;
                angle.y = pos.y * buttonAngle;

                angleList.Add(angle);
            }
        Vector2 buttonCenter = LayoutCalculator.meanAngle(angleList);

        //calculate button length
        float width = size.x * buttonLength;
        float height = size.y * buttonLength;

        //Setup the button
        button.GetComponent<ButtonCurvedEffect>().setButton(buttonManager.gameObject, width, height, buttonCenter.y + VerticalAngle, buttonCenter.x + HorizontalAngle + forwardAngle);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutCalculator{

    public static float partialLength(float angle, float radius) {
        
        float perimeter = 2 * Mathf.PI * radius;

        return perimeter * angle / 360.0f;
    }

    public static float paritalAngle(float length, float radius)
    {
        float perimeter = 2 * Mathf.PI * radius;

        return length / perimeter * 360.0f;
    }

    public static Vector2 meanAngle(List<Vector2> angleList)
    {
        Vector2 mean = Vector2.zero;
        for (int i = 0; i < angleList.Count; i++)
            mean += angleList[i];

        return mean / (float)angleList.Count;
    }
}

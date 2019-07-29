using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SphereDataLoader : MonoBehaviour {

    public static SphereData sphereLoad;

    public static SphereData loadSphere()
    {
        sphereLoad = new SphereData(Vector3.zero, -1) ;

        FileInfo theSourceFile = null;
        StreamReader reader = null;

        theSourceFile = new FileInfo("Assets/SphereResource/" + SphereDataWriter.FileName);

        if (!theSourceFile.Exists)
            return sphereLoad;
        reader = theSourceFile.OpenText();

        String center_string = reader.ReadLine();
        String radius_string = reader.ReadLine();

        sphereLoad = new SphereData(parseCenter(center_string),parseRadius(radius_string));

        reader.Dispose();

        print("SphereDataLoader: Finish Reading");
        print("Center: " + sphereLoad.center);
        print("Radius: " + sphereLoad.radius);
        return sphereLoad;
 
    }

    static Vector3 parseCenter(string center)
    {
        String num_spilt = ",";

        String vec_spilt = "(";
        center = center.Split(vec_spilt.ToCharArray())[1];
        vec_spilt = ")";
        center = center.Split(vec_spilt.ToCharArray())[0];

        String[] numbers = center.Split(num_spilt.ToCharArray());
        Vector3 position = new Vector3(float.Parse(numbers[0]), float.Parse(numbers[1]), float.Parse(numbers[2]));

        return position;
    }

    static float parseRadius(string radius)
    {
        return float.Parse(radius);
    }
}

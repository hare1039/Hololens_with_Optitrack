using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SphereDataWriter : MonoBehaviour {

    public static string FileName = "SphereData.txt";

	public static void writeSphereData(Vector3 center, float radius)
    {
        StreamWriter writestream = File.CreateText("Assets/SphereResource/" + FileName);
        writestream.WriteLine("("+center.x+","+center.y+","+center.z+")");
        writestream.WriteLine(radius);
        //writestream.WriteLine(offset);

        writestream.Dispose();
        print("SphereDataWriter: Finish writing");
    }
}

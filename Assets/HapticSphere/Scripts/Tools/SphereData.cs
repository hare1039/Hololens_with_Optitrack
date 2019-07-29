using UnityEngine;
using System.Collections;

public class SphereData {

	public float radius;
	public Vector3 center;
    public int vote, maxvote;

	public SphereData(Vector3 _center, float _radius){
		center = _center;
		radius = _radius;
	}
}

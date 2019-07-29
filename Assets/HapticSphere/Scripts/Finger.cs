using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finger : MonoBehaviour {

	// Use this for initialization
	#region Singleton
	public static Finger instance;
	void Awake()
	{
		instance = this;
	}
	#endregion 
}

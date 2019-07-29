using UnityEngine;
using System.Collections;

public abstract class MathNetExampleBase : MonoBehaviour {
  
	void Update () {
    if(Input.GetKeyDown(KeyCode.N)) {
      ExecuteExample();
    }
	}

  public abstract void ExecuteExample();
}

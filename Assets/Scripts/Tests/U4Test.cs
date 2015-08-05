using UnityEngine;
using me.mholub.u4.core;

public class U4Test : MonoBehaviour {
	// Use this for initialization
	void Start () {
		var p = new Pin<int>();
		p.Value = 5;
		Debug.LogFormat("int pin value: {0}", p.Value);
	}

}

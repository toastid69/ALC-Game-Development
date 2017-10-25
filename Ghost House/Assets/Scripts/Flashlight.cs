using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour {

	public bool lightOn;

	Light light;

	void Start ()
	{
		light = GetComponent<Light> ();
		//Set Light default to ON
		lightOn = true;
		light.enabled = true;
	}

	void Update ()
	{
		if (Input.GetKeyUp (KeyCode.F) && lightOn)
		{
			lightOn = false;
			light.enabled = false;
		}

		else if (Input.GetKeyUp (KeyCode.F) && !lightOn)
		{
			lightOn = true;
			light.enabled = true;
		}
	}
	
	}
}

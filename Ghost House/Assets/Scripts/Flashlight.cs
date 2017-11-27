using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlashLight : MonoBehaviour {

	public bool lightOn;

	//Flashlight power capacity
	public int maxPower = 4;
	//Useable flashlight power
	public int currentPower;

	Light light;

	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("power = " + currentPower);

		light = GetComponent<Light> ();
		//Set Light default to ON
		lightOn = true;
		light.enabled = true;
	}

	void Update () {
		if (Input.GetKeyUp (KeyCode.L) && lightOn)
		{
			lightOn = false;
			light.enabled = false;
		}

		else if (Input.GetKeyUp (KeyCode.L) && !lightOn)
		{
			lightOn = true;
			light.enabled = true;
		}
	}
	public void setLightOn(){
		lightOn = true;
	}

	public bool isLightOn(){
		return lightOn;
	}
	
}

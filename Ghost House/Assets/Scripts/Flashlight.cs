﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FlashLight : MonoBehaviour {

	public bool lightOn = true;
	//Flashlight power capacity
	public int maxPower = 4;
	//Useable flashlight power
	public int currentPower;

	public int batDrainAmt;

	public float batDrainDelay;

	Light light;

	//Gets Battery UI Text
	public Text batteryText;

	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("Power = " + currentPower);

		light = GetComponent<Light> ();
		//Set Light default to ON
		lightOn = true;
		print("Turn light on then FlashLight is initiated");
		light.enabled = true;
	}

	void Update () {
		//Toggle Light on/off when L is pressed
		if (Input.GetKeyUp (KeyCode.L) && lightOn)
		{
			print("Light off");
			lightOn = false;
			light.enabled = false;
		}

		else if (Input.GetKeyUp (KeyCode.L) && !lightOn)
		{
			print("Light on");
			lightOn = true;
			light.enabled = true;
		}
		//Update Battery UI Text
		batteryText.text = currentPower.ToString();

		//Drain Battery Life
		if(currentPower > 0){
			StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
		}		
	}
	public void setLightOn(){
		lightOn = true;
	}

	public bool isLightOn(){
		return lightOn;
	}

	IEnumerator BatteryDrain(float delay, int amount){
		yield return new WaitForSeconds(delay);
		currentPower -= amount;
		if(currentPower <= 0){
			currentPower = 0;
			print("Battery is dead!");
			light.enabled = false;
		}
	}
	
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FlashLight : MonoBehaviour {

	//Flashlight on / off
	public bool lightOn = true;
	//Flashlight power capacity
	public int maxPower = 4;
	//Useable flashlight power
	public int currentPower;
	//Flashlight drain amount
	public int batDrainAmt;
	//Flashlight drain delay
	public float batDrainDelay;
	//Stores light object
	Light light;
	//Battery drain on/off
	bool draining = false;
	//Count integer
	long count = 0;
	//Gets Battery UI Text
	public Text batteryText;

	void Start () {
		//Add power to flashlight
		currentPower = maxPower;
		print("Power = " + currentPower);
		//Get Light
		light = GetComponent<Light> ();
		//Set Light default to ON
		lightOn = true;
		print("Turn light on then FlashLight is initiated");
		light.enabled = true;
	}

	void Update () {
		//Toggle Light on/off when L is pressed
		if (Input.GetKeyUp (KeyCode.L) && lightOn){
			print("Light off");
			lightOn = false;
			light.enabled = false;
		}

		else if (Input.GetKeyUp (KeyCode.L) && !lightOn && currentPower > 0){
			print("Light on");
			lightOn = true;
			light.enabled = true;
		}
		//Update Battery UI Text
		batteryText.text = currentPower.ToString();

		//Drain Battery Life
		if(currentPower > 0 && lightOn){
			if(!draining){
				StartCoroutine(BatteryDrain(batDrainDelay,batDrainAmt));
			}
			else if(currentPower <= 0){
				lightOn = false;
				light.enabled = false;
			}
		}
	}
	// Turns light on when called
	public void setLightOn(){
		lightOn = true;
	}
	//Returns if light is on
	public bool isLightOn(){
		return lightOn;
	}
	//Drain Battery Life
	IEnumerator BatteryDrain(float delay, int amount){
		if(lightOn){
				draining = true;
				yield return new WaitForSeconds(delay);
				print(currentPower);
				currentPower -= amount;
			}

			if(currentPower <= 0){
				currentPower = 0;
				print("Battery is dead!");
				light.enabled = false;
		}

		draining = false;
	}
	
}

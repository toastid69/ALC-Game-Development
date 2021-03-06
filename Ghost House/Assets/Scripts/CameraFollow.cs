﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public Vector3 defaultDistance = new Vector3(0f,2f,-5f);
	public float distDamp = 10f;
	public float rotDamp = 10f;

	Transform myTrans;

	// Use this for initialization
	void Awake () {
		myTrans = transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		//Change camera position
		Vector3 toPos = target.position + (target.rotation * defaultDistance);
		Vector3 curPos = Vector3.Lerp(myTrans.position, toPos, distDamp * Time.deltaTime);
		myTrans.position = curPos;

		//Change camera rotation
		Quaternion toRot = Quaternion.LookRotation(target.position - myTrans.position, target.up);
		Quaternion curRot = Quaternion.Slerp(myTrans.rotation, toRot, rotDamp * Time.deltaTime);
		myTrans.rotation = curRot;
	}
}

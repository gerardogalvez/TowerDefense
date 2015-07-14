﻿using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject castle = GameObject.Find("Castle");

		if (castle)
			this.GetComponent<NavMeshAgent> ().destination = castle.transform.position;
	}

	void OnTriggerEnter(Collider co)
	{
		if (co.name == "Castle") {
			co.GetComponentInChildren<Health> ().decreaseHealth ();
			Destroy (gameObject);
		}
	}
}

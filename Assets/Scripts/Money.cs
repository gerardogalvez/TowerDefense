﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Money : MonoBehaviour {

	public static int money = 100;
	public Text moneyText;

	void Update(){
		moneyText.text = "Money: " + money.ToString();
	}
}
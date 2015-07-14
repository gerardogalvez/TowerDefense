using UnityEngine;
using System.Collections;

public class Buildplace : MonoBehaviour {

	public GameObject towerPrefab;
	private bool towerBuilt = false;

	void OnMouseUpAsButton()
	{
		if (Money.money >= 85 && towerBuilt == false) {
			// Instantiate tower and position it one unit above the buildplace (this)
			GameObject tower = (GameObject)Instantiate (towerPrefab);
			tower.transform.position = this.transform.position + Vector3.up;
			Money.money -= 85;
			towerBuilt = true;
		}
	}
}

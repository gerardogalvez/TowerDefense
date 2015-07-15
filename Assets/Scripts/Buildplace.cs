using UnityEngine;
using System.Collections;

public class Buildplace : MonoBehaviour {

	public GameObject towerPrefab;
	public GameObject towerUpgradedPrefab;
	private bool towerBuilt = false;
	private bool isUpgraded = false;
	private GameObject tower = null;
	private GameObject upTower = null;

	void OnMouseUpAsButton()
	{
		if (Money.money >= 85 && !towerBuilt && !isUpgraded) {
			// Instantiate tower and position it one unit above the buildplace (this)
			tower = (GameObject)Instantiate (towerPrefab);
			tower.transform.position = this.transform.position + Vector3.up;
			Money.money -= 85;
			towerBuilt = true;
		} else if (towerBuilt && Money.money >= 150 && !isUpgraded) {
			Destroy(tower.gameObject);
			upTower = (GameObject)Instantiate (towerUpgradedPrefab);
			upTower.transform.position = this.transform.position + Vector3.up;
			Money.money -= 150;
			isUpgraded = true;
		}
	}
}

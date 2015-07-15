using UnityEngine;
using System.Collections;

// --- Upgraded Tower ---
// Cost to upgrade: $150
// Fire rate: 1 bullet each 0.75 seconds
// Damage: 90
public class upgradedTower : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject monster = null;
	public float rotationSpeed = 35;
	private float nextFire = 0;
	private float fireRate = 0.75f;
	public static int damage = 90;
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}
	
	void OnTriggerStay(Collider co)
	{
		if (co.GetComponent<Monster> () && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject bullet = (GameObject)Instantiate (bulletPrefab, this.transform.position, Quaternion.identity);
			bullet.GetComponent<Bullet>().bulletDamage = upgradedTower.damage;
			bullet.GetComponent<Bullet> ().target = co.transform;
		}
	}
}

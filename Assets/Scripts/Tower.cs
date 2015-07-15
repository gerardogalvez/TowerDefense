using UnityEngine;
using System.Collections;

// --- Basic Tower ---
// Cost: $85
// Fire rate: 1 bullet per second
// Damage: 50
public class Tower : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject monster = null;
	public float rotationSpeed = 35;
	private float nextFire = 0;
	private float fireRate = 1f;
	public static int damage = 50;
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}

	void OnTriggerStay(Collider co)
	{
		if (co.GetComponent<Monster> () && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			GameObject bullet = (GameObject)Instantiate (bulletPrefab, this.transform.position, Quaternion.identity);
			bullet.GetComponent<Bullet>().bulletDamage = Tower.damage;
			bullet.GetComponent<Bullet> ().target = co.transform;
		}
	}
}

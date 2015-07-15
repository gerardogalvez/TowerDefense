using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private float speed = 10;
	public int bulletDamage;

	public Transform target;

	void FixedUpdate()
	{
		// Bullet has a target?
		if (target) {
			//Approach target's position
			Vector3 dir = target.position - this.transform.position;
			this.GetComponent<Rigidbody> ().velocity = dir.normalized * speed;
		} else
			//Destroy bullet
			Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider monster)
	{
		if (monster.name == "Monster(Clone)") {
			MonsterHealth monsterHealth = monster.GetComponentInChildren<MonsterHealth> ();
			if (monsterHealth) {
				monsterHealth.decreaseHealth(bulletDamage);
				Destroy(this.gameObject);
			}
		}
	}
}

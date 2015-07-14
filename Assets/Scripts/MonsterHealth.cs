using UnityEngine;
using System.Collections;

public class MonsterHealth : MonoBehaviour {

	public int health = 100;

	/*public int currentHealth()
	{
		return health;
	}*/

	public void decreaseHealth(int damage)
	{
		health = health - damage;
		if (health <= 0){
			Destroy (gameObject);
			Money.money += 15;
		}
	}
}

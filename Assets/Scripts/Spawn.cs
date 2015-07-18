using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Spawn : MonoBehaviour {

	public GameObject monsterPrefab;

	public float waveStart;
	public float time;

	public Text waveBeaten;
	public int wave;

	private float interval = 3;
	public int healthIncrease;
	public bool hasHealthIncreased = false;

	void Awake()
	{
		waveStart = (float)Time.time;
	}

	// Use this for initialization
	void Start () {
		wave = 1;
		healthIncrease = 45;
		//Debug.Log("Health increase on wave " + wave.ToString() + ": " + healthIncrease.ToString());
		monsterPrefab.GetComponent<MonsterHealth> ().health = 100;
		InvokeRepeating ("SpawnNext", 0, interval);
		waveBeaten.text = "Current wave: " + wave.ToString ();
	}

	void Update()
	{
		time = (float)Time.time;

		/*if (wave % 10 == 0 && hasHealthIncreased == false) {
			Debug.Log("Before increase: " + healthIncrease.ToString());
			healthIncrease += 15;
			Debug.Log("After increase: " + healthIncrease.ToString());
			hasHealthIncreased = true;
		}*/

		// Stop spawning after 10 seconds since wave starts.
		if (time > waveStart + 10) {
			CancelInvoke ("SpawnNext");
		} 

		// Start spawning after 8 seconds after last wave.
		if (time > waveStart + 16) {
			waveStart = (float)Time.time;

			monsterPrefab.GetComponent<MonsterHealth>().health += healthIncrease;
			// Make enemies spawn faster.
			if (interval > 1.0f)
				interval -= 0.29f;

			InvokeRepeating ("SpawnNext", 0, interval);
			wave++;
			//Debug.Log("Health increase on wave " + wave.ToString() + ": " + healthIncrease.ToString());
			waveBeaten.text = "Current wave: " + wave.ToString ();
		}
	}

	void SpawnNext()
	{
		Instantiate (monsterPrefab, this.transform.position, Quaternion.identity);
	}
}

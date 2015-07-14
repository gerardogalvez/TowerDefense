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

	void Awake()
	{
		waveStart = (float)Time.time;
	}

	// Use this for initialization
	void Start () {
		wave = 1;
		monsterPrefab.GetComponent<MonsterHealth> ().health = 100;
		InvokeRepeating ("SpawnNext", 0, interval);
		waveBeaten.text = "Current wave: " + wave.ToString ();
	}

	void Update()
	{
		time = (float)Time.time;
		// Stop spawning after 10 seconds since wave starts.
		if (time > waveStart + 10) {
			CancelInvoke ("SpawnNext");
		} 

		// Start spawning after 8 seconds after last wave.
		if (time > waveStart + 18) {
			waveStart = (float)Time.time;

			monsterPrefab.GetComponent<MonsterHealth>().health += 45;

			// Make enemies spawn faster.
			if (interval > 1.3f)
				interval -= 0.29f;

			InvokeRepeating ("SpawnNext", 0, interval);
			wave++;
			waveBeaten.text = "Current wave: " + wave.ToString ();
		}
	}

	void SpawnNext()
	{
		Instantiate (monsterPrefab, this.transform.position, Quaternion.identity);
	}
}

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	TextMesh tm;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.forward = Camera.main.transform.forward;
	}

	public int currentHealth()
	{
		return tm.text.Length;
	}

	public void decreaseHealth()
	{
		if (this.currentHealth () > 1)
			tm.text = tm.text.Remove (tm.text.Length - 1);
		else {
			Destroy (this.transform.parent.gameObject);
			Application.LoadLevel("menu");
		}
	}
}

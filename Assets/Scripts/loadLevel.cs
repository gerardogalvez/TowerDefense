using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

	public void load(string sceneToLoad){
		Application.LoadLevel (sceneToLoad);
	}
}
